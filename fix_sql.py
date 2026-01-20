import re
import sys

def fix_sql(filepath):
    print(f"Fixing {filepath}...")
    with open(filepath, 'rb') as f:
        content = f.read()

    # Remove common BOMs
    # UTF-8: EF BB BF
    # UTF-16 BE: FE FF
    # UTF-16 LE: FF FE
    
    for bom in [b'\xef\xbb\xbf', b'\xfe\xff', b'\xff\xfe']:
        if content.startswith(bom):
            content = content[len(bom):]
            break

    # Also remove the latin1 representation of BOM if it's double-encoded or something
    # ï»¿ is \xef\xbb\xbf
    # Sometimes it appears as bytes directly
    
    # Try to decode safely
    try:
        text = content.decode('utf-8')
    except UnicodeDecodeError:
        text = content.decode('latin1')

    # Aggressively remove non-printable/hidden chars at the start
    text = text.lstrip('\ufeff\ufeff') # Sometimes there are multiple
    text = text.lstrip('ï»¿')
    text = text.strip()

    # Replace curly quotes and other common non-ASCII
    text = text.replace('\u2019', "'").replace('\u2018', "'")
    text = text.replace('\u201c', '"').replace('\u201d', '"')
    
    # Replace common symbols that might cause issues
    text = text.replace('âœ…', '[OK]')
    text = text.replace('ðŸ”¹', '>')
    text = text.replace('â€"', '-')
    text = text.replace('â‚¹', 'Rs.')
    text = text.replace('âœ…', '[OK]')

    # Add GO before CREATE/ALTER/USE/DROP/EXEC
    # We want to match these at the start of a line (after optional whitespace)
    # but NOT if they are preceded by BEGIN or other procedure keywords.
    # However, a simpler way is to just look for these keywords at the start of a line.
    
    pattern = re.compile(r'\n\s*(CREATE|ALTER|USE|DROP|EXEC|EXECUTE)\s+(PROCEDURE|PROC|TABLE|VIEW|DATABASE|FUNCTION|TRIGGER|DATABASE|DATABASE|\[?\w+\]?)', re.IGNORECASE)
    
    def replacement(match):
        # Don't add GO if it's already there
        # This is simple, just prefix with GO
        return f'\nGO\n{match.group(0).strip()}'
        
    fixed_content = pattern.sub(replacement, text)
    
    # Clean up redundant GOs
    fixed_content = re.sub(r'\nGO\nGO\n', r'\nGO\n', fixed_content)
    fixed_content = re.sub(r'GO\s+GO', 'GO', fixed_content)

    # Ensure it starts with clean text
    fixed_content = fixed_content.strip()

    with open(filepath, 'w', encoding='utf-8') as f:
        f.write(fixed_content)

if __name__ == "__main__":
    for arg in sys.argv[1:]:
        fix_sql(arg)
