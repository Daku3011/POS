import re

def extract_procedures(filename):
    with open(filename, 'r', encoding='utf-8', errors='ignore') as f:
        content = f.read()

    # Normalize line endings
    content = content.replace('\r\n', '\n')
    
    # Split into lines
    lines = content.split('\n')
    
    new_content = ["USE EchoPay\nGO\n"]
    in_block = False
    current_block = []
    level = 0
    
    for line in lines:
        stripped = line.strip()
        upper_stripped = stripped.upper()
        
        # Detect start of procedure
        if re.search(r'CREATE\s+(OR\s+ALTER\s+)?PROCEDURE', stripped, re.IGNORECASE):
            in_block = True
            current_block = []
            level = 0
            # Standardize to CREATE OR ALTER
            line = re.sub(r'CREATE\s+(OR\s+ALTER\s+)?PROCEDURE', 'CREATE OR ALTER PROCEDURE', line, flags=re.IGNORECASE)
            
        if in_block:
            current_block.append(line)
            # Count BEGIN/END
            if upper_stripped == 'BEGIN' or upper_stripped.startswith('BEGIN '):
                level += 1
            elif upper_stripped == 'END' or upper_stripped == 'END;' or upper_stripped.startswith('END '):
                level -= 1
                if level <= 0:
                    # End of procedure reached
                    new_content.append('GO\n')
                    new_content.extend([l + '\n' for l in current_block])
                    new_content.append('GO\n')
                    in_block = False
                    current_block = []

    # Final pass to remove non-ASCII and ensure clean encoding
    final_output = "".join(new_content)
    final_output = "".join(c for c in final_output if ord(c) < 128)
    
    with open(filename, 'w', encoding='utf-8') as f:
        f.write(final_output)

if __name__ == "__main__":
    extract_procedures('Sp EchoPay.sql')
    print("Extracted procedures from Sp EchoPay.sql")
