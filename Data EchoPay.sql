use EchoPay

-- Insert Data into Menu Table
Select * from Menu
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
-- Chaat
(1, 'Pani Puri', 'Crispy puris filled with spicy and tangy water', 50.00, 'https://elcorestaurants.com/images/pani_puri.jpg', 1),
(1, 'Bhel Puri', 'A crunchy mix of puffed rice, sev, and tangy chutneys', 60.00, 'https://elcorestaurants.com/images/bhel_puri.jpg', 1),
(1, 'Dahi Puri', 'Stuffed puris topped with sweet curd and chutneys', 70.00, 'https://elcorestaurants.com/images/dahi_puri.jpg', 1),
(1, 'Sev Puri', 'Crispy puris topped with potatoes, sev, and chutneys', 65.00, 'https://elcorestaurants.com/images/sev_puri.jpg', 1),
(1, 'Raj Kachori', 'A large kachori stuffed with delicious fillings and chutneys', 80.00, 'https://elcorestaurants.com/images/raj_kachori.jpg', 1),
(1, 'Papdi Chaat', 'Crispy papdi topped with curd, sev, and chutneys', 75.00, 'https://elcorestaurants.com/images/papdi_chaat.jpg', 1),
(1, 'Aloo Tikki', 'Spiced mashed potato patties served with chutneys', 90.00, 'https://elcorestaurants.com/images/aloo_tikki.jpg', 1),
(1, 'Dahi Bhalla', 'Soft lentil dumplings soaked in sweetened curd', 85.00, 'https://elcorestaurants.com/images/dahi_bhalla.jpg', 1),
(1, 'Samosa Chaat', 'Crispy samosas crushed and mixed with chutneys', 95.00, 'https://elcorestaurants.com/images/samosa_chaat.jpg', 1),
(1, 'Kachori Chaat', 'Flaky kachoris broken and mixed with tangy chutneys', 90.00, 'https://elcorestaurants.com/images/kachori_chaat.jpg', 1),

-- Sandwich
(2, 'Veg Grilled Sandwich', 'Grilled sandwich loaded with veggies and cheese', 120.00, 'https://www.chefajaychopra.com/images/veg_grilled_sandwich.jpg', 1),
(2, 'Club Sandwich', 'Layered sandwich with fresh veggies and sauces', 150.00, 'https://www.chefajaychopra.com/images/club_sandwich.jpg', 1),
(2, 'Paneer Tikka Sandwich', 'Sandwich stuffed with spiced paneer tikka', 170.00, 'https://www.chefajaychopra.com/images/paneer_tikka_sandwich.jpg', 1),
(2, 'Cheese Chutney Sandwich', 'A simple yet delicious sandwich with cheese and green chutney', 100.00, 'https://www.chefajaychopra.com/images/cheese_chutney_sandwich.jpg', 1),
(2, 'Corn and Spinach Sandwich', 'Healthy sandwich filled with corn and spinach', 130.00, 'https://www.chefajaychopra.com/images/corn_spinach_sandwich.jpg', 1),
(2, 'Mumbai Masala Toast', 'Spiced mashed potato sandwich toasted to perfection', 140.00, 'https://www.chefajaychopra.com/images/mumbai_masala_toast.jpg', 1),
(2, 'Italian Pesto Sandwich', 'Sandwich with fresh pesto and cheese', 160.00, 'https://www.chefajaychopra.com/images/italian_pesto_sandwich.jpg', 1),
(2, 'Egg Mayo Sandwich', 'Creamy egg and mayo sandwich', 180.00, 'https://www.chefajaychopra.com/images/egg_mayo_sandwich.jpg', 1),
(2, 'Chicken Club Sandwich', 'Delicious chicken club sandwich', 200.00, 'https://www.chefajaychopra.com/images/chicken_club_sandwich.jpg', 1),
(2, 'BBQ Chicken Sandwich', 'Grilled chicken with BBQ sauce in a sandwich', 220.00, 'https://www.chefajaychopra.com/images/bbq_chicken_sandwich.jpg', 1),

-- Pizza
(3, 'Margherita Pizza', 'Classic pizza with cheese and tomato sauce', 250.00, 'https://www.dominos.co.in/menu/margherita-pizza.jpg', 1),
(3, 'Veggie Delight Pizza', 'Pizza loaded with fresh vegetables', 270.00, 'https://www.dominos.co.in/menu/veggie-delight.jpg', 1),
(3, 'Paneer Tikka Pizza', 'Pizza topped with spiced paneer tikka', 290.00, 'https://www.dominos.co.in/menu/paneer-tikka-pizza.jpg', 1),
(3, 'Pepperoni Pizza', 'Classic pepperoni pizza', 310.00, 'https://www.dominos.co.in/menu/pepperoni-pizza.jpg', 1),
(3, 'BBQ Chicken Pizza', 'Pizza with grilled chicken and BBQ sauce', 330.00, 'https://www.dominos.co.in/menu/bbq-chicken-pizza.jpg', 1),
(3, 'Cheese Burst Pizza', 'Pizza with a delicious cheese-filled crust', 350.00, 'https://www.dominos.co.in/menu/cheese-burst-pizza.jpg', 1),
(3, 'Mushroom Delight Pizza', 'Pizza with fresh mushrooms and cheese', 270.00, 'https://www.dominos.co.in/menu/mushroom-delight.jpg', 1),
(3, 'Farmhouse Pizza', 'A mix of fresh farm veggies and cheese', 290.00, 'https://www.dominos.co.in/menu/farmhouse-pizza.jpg', 1),
(3, 'Four Cheese Pizza', 'A heavenly mix of four types of cheese', 310.00, 'https://www.dominos.co.in/menu/four-cheese-pizza.jpg', 1),
(3, 'Tandoori Chicken Pizza', 'A fusion of Indian tandoori flavors with pizza', 350.00, 'https://www.dominos.co.in/menu/tandoori-chicken-pizza.jpg', 1);

-- Finger Bites (Category 4)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(4, 'French Fries', 'Crispy golden potato fries served with ketchup', 80.00, 'https://www.shutterstock.com/image-photo/french-fries-260nw-1036253591.jpg', 1),
(4, 'Cheesy Fries', 'Fries loaded with gooey melted cheese', 120.00, 'https://www.gettyimages.com/photos/cheesy-fries', 1),
(4, 'Potato Wedges', 'Thick-cut crispy potato wedges', 90.00, 'https://www.shutterstock.com/image-photo/potato-wedges-260nw-193740739.jpg', 1),
(4, 'Onion Rings', 'Crispy battered onion rings', 100.00, 'https://www.shutterstock.com/image-photo/onion-rings-260nw-193740739.jpg', 1),
(4, 'Cheese Balls', 'Crispy fried cheese-filled bites', 130.00, 'https://www.shutterstock.com/image-photo/cheese-balls-260nw-193740739.jpg', 1),
(4, 'Chicken Nuggets', 'Bite-sized crispy fried chicken nuggets', 150.00, 'https://www.shutterstock.com/image-photo/chicken-nuggets-260nw-193740739.jpg', 1),
(4, 'Paneer Popcorn', 'Crispy fried paneer bites', 140.00, 'https://www.shutterstock.com/image-photo/paneer-popcorn-260nw-193740739.jpg', 1),
(4, 'Veg Spring Rolls', 'Crispy rolls filled with mixed veggies', 160.00, 'https://www.shutterstock.com/image-photo/veg-spring-rolls-260nw-193740739.jpg', 1),
(4, 'Jalapeno Poppers', 'Spicy jalapeno bites stuffed with cheese', 180.00, 'https://www.shutterstock.com/image-photo/jalapeno-poppers-260nw-193740739.jpg', 1),
(4, 'Chicken Wings', 'Spicy and crispy chicken wings', 200.00, 'https://www.shutterstock.com/image-photo/chicken-wings-260nw-193740739.jpg', 1);

-- Croissants (Category 5)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(5, 'Classic Croissant', 'Buttery, flaky croissant', 100.00, 'https://www.shutterstock.com/image-photo/classic-croissant-260nw-193740739.jpg', 1),
(5, 'Chocolate Croissant', 'Croissant filled with rich chocolate', 120.00, 'https://www.shutterstock.com/image-photo/chocolate-croissant-260nw-193740739.jpg', 1),
(5, 'Cheese Croissant', 'Croissant stuffed with melted cheese', 140.00, 'https://www.shutterstock.com/image-photo/cheese-croissant-260nw-193740739.jpg', 1),
(5, 'Almond Croissant', 'Sweet croissant topped with almonds', 150.00, 'https://www.shutterstock.com/image-photo/almond-croissant-260nw-193740739.jpg', 1),
(5, 'Strawberry Croissant', 'Croissant filled with fresh strawberry jam', 160.00, 'https://www.shutterstock.com/image-photo/strawberry-croissant-260nw-193740739.jpg', 1),
(5, 'Blueberry Croissant', 'Croissant with a blueberry filling', 170.00, 'https://www.shutterstock.com/image-photo/blueberry-croissant-260nw-193740739.jpg', 1),
(5, 'Nutella Croissant', 'Croissant stuffed with Nutella', 180.00, 'https://www.instagram.com/supermoonbakehouse/p/C_YUNkvxYjA/', 1),
(5, 'Banana Caramel Croissant', 'Croissant filled with banana and caramel', 190.00, 'https://www.shutterstock.com/image-photo/banana-caramel-croissant-260nw-193740739.jpg', 1),
(5, 'Pistachio Croissant', 'Croissant topped with crushed pistachios', 200.00, 'https://www.instagram.com/merakibakehouse_/p/DFNqv2Ax4-Q/', 1),
(5, 'Matcha Croissant', 'Unique matcha-flavored croissant', 220.00, 'https://www.shutterstock.com/image-photo/matcha-croissant-260nw-193740739.jpg', 1);

-- Pizza (Category 6)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(6, 'Margherita Pizza', 'Classic pizza with cheese and tomato sauce', 250.00, 'https://www.shutterstock.com/image-photo/margherita-pizza-260nw-193740739.jpg', 1),
(6, 'Farmhouse Pizza', 'Loaded with fresh vegetables and cheese', 270.00, 'https://www.shutterstock.com/image-photo/farmhouse-pizza-260nw-193740739.jpg', 1),
(6, 'Paneer Tikka Pizza', 'Topped with spiced paneer tikka', 290.00, 'https://www.shutterstock.com/image-photo/paneer-tikka-pizza-260nw-193740739.jpg', 1),
(6, 'BBQ Chicken Pizza', 'Grilled chicken with BBQ sauce on pizza', 320.00, 'https://www.shutterstock.com/image-photo/bbq-chicken-pizza-260nw-193740739.jpg', 1),
(6, 'Four Cheese Pizza', 'Combination of four types of cheese', 350.00, 'https://www.shutterstock.com/image-photo/four-cheese-pizza-260nw-193740739.jpg', 1),
(6, 'Mushroom Delight Pizza', 'Topped with fresh mushrooms and cheese', 280.00, 'https://www.shutterstock.com/image-photo/mushroom-delight-pizza-260nw-193740739.jpg', 1),
(6, 'Tandoori Chicken Pizza', 'Spiced tandoori chicken on pizza', 370.00, 'https://www.shutterstock.com/image-photo/tandoori-chicken-pizza-260nw-193740739.jpg', 1),
(6, 'Pepperoni Pizza', 'Classic pepperoni pizza', 330.00, 'https://www.shutterstock.com/image-photo/pepperoni-pizza-260nw-193740739.jpg', 1)



-- Salads (Category 7)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(7, 'Greek Salad', 'Fresh salad with feta cheese and olives', 180.00, 'https://example.com/images/greek_salad.jpg', 1),
(7, 'Caesar Salad', 'Classic salad with Caesar dressing and croutons', 200.00, 'https://example.com/images/caesar_salad.jpg', 1),
(7, 'Caprese Salad', 'Tomatoes, mozzarella, and basil with balsamic glaze', 190.00, 'https://example.com/images/caprese_salad.jpg', 1),
(7, 'Quinoa Salad', 'Healthy quinoa with mixed veggies and dressing', 220.00, 'https://example.com/images/quinoa_salad.jpg', 1),
(7, 'Pasta Salad', 'Pasta mixed with fresh veggies and dressing', 210.00, 'https://example.com/images/pasta_salad.jpg', 1),
(7, 'Grilled Chicken Salad', 'Fresh greens topped with grilled chicken', 250.00, 'https://example.com/images/grilled_chicken_salad.jpg', 1),
(7, 'Asian Sesame Salad', 'Salad with sesame dressing and crunchy toppings', 230.00, 'https://example.com/images/asian_sesame_salad.jpg', 1),
(7, 'Sprouts Salad', 'Nutritious sprouts with a zesty dressing', 170.00, 'https://example.com/images/sprouts_salad.jpg', 1),
(7, 'Avocado Salad', 'Creamy avocado with greens and citrus dressing', 260.00, 'https://example.com/images/avocado_salad.jpg', 1),
(7, 'Beetroot Walnut Salad', 'Refreshing beetroot salad with crunchy walnuts', 240.00, 'https://example.com/images/beetroot_walnut_salad.jpg', 1);

-- Dessert (Category 8)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(8, 'Chocolate Brownie', 'Rich, fudgy chocolate brownie', 120.00, 'https://example.com/images/chocolate_brownie.jpg', 1),
(8, 'Gulab Jamun', 'Soft and syrupy Indian dessert', 100.00, 'https://example.com/images/gulab_jamun.jpg', 1),
(8, 'Rasmalai', 'Delicate cheese dumplings soaked in creamy milk', 140.00, 'https://example.com/images/rasmalai.jpg', 1),
(8, 'Mango Pudding', 'Sweet and creamy mango-flavored dessert', 160.00, 'https://example.com/images/mango_pudding.jpg', 1),
(8, 'Tiramisu', 'Classic Italian coffee-flavored dessert', 180.00, 'https://example.com/images/tiramisu.jpg', 1),
(8, 'Chocolate Lava Cake', 'Chocolate cake with a molten center', 200.00, 'https://example.com/images/lava_cake.jpg', 1),
(8, 'Carrot Halwa', 'Warm and rich carrot dessert with nuts', 150.00, 'https://example.com/images/carrot_halwa.jpg', 1),
(8, 'Ice Cream Sundae', 'Assorted ice cream with toppings', 170.00, 'https://example.com/images/ice_cream_sundae.jpg', 1),
(8, 'Kheer', 'Creamy Indian rice pudding', 130.00, 'https://example.com/images/kheer.jpg', 1),
(8, 'Fruit Custard', 'Mixed fruits in creamy custard', 140.00, 'https://example.com/images/fruit_custard.jpg', 1);

-- Cheesecake (Category 9)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(9, 'Classic New York Cheesecake', 'Rich and creamy cheesecake', 250.00, 'https://example.com/images/newyork_cheesecake.jpg', 1),
(9, 'Blueberry Cheesecake', 'Cheesecake topped with blueberry compote', 270.00, 'https://example.com/images/blueberry_cheesecake.jpg', 1),
(9, 'Strawberry Cheesecake', 'Cheesecake with fresh strawberries', 260.00, 'https://example.com/images/strawberry_cheesecake.jpg', 1),
(9, 'Chocolate Cheesecake', 'Cheesecake with rich chocolate ganache', 280.00, 'https://example.com/images/chocolate_cheesecake.jpg', 1),
(9, 'Caramel Cheesecake', 'Cheesecake drizzled with caramel sauce', 290.00, 'https://example.com/images/caramel_cheesecake.jpg', 1),
(9, 'Mango Cheesecake', 'Cheesecake with a mango twist', 300.00, 'https://example.com/images/mango_cheesecake.jpg', 1),
(9, 'Oreo Cheesecake', 'Cheesecake with crushed Oreos', 310.00, 'https://example.com/images/oreo_cheesecake.jpg', 1),
(9, 'Biscoff Cheesecake', 'Cheesecake with a Biscoff biscuit base', 320.00, 'https://example.com/images/biscoff_cheesecake.jpg', 1),
(9, 'Red Velvet Cheesecake', 'Cheesecake with red velvet layers', 330.00, 'https://example.com/images/redvelvet_cheesecake.jpg', 1),
(9, 'Nutella Cheesecake', 'Cheesecake infused with Nutella', 340.00, 'https://example.com/images/nutella_cheesecake.jpg', 1);

-- Quick Bites (Category 10)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(10, 'Samosa', 'Crispy fried pastry with spicy potato filling', 50.00, 'https://example.com/images/samosa.jpg', 1),
(10, 'Vada Pav', 'Mumbai-style spicy potato fritter in a bun', 60.00, 'https://example.com/images/vada_pav.jpg', 1),
(10, 'Dhokla', 'Soft and spongy steamed gram flour snack', 70.00, 'https://example.com/images/dhokla.jpg', 1),
(10, 'Pakora', 'Crispy gram flour battered fritters', 80.00, 'https://example.com/images/pakora.jpg', 1),
(10, 'Kachori', 'Flaky, stuffed deep-fried snack', 90.00, 'https://example.com/images/kachori.jpg', 1)

--  (Category 11)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(11, 'Chef’s Special Pasta', 'Unique pasta creation of the day', 250.00, 'https://example.com/images/chefs_special_pasta.jpg', 1),
(11, 'Mystery Sandwich', 'A surprise sandwich with unique ingredients', 200.00, 'https://example.com/images/mystery_sandwich.jpg', 1),
(11, 'Spicy Nachos Surprise', 'Loaded nachos with a mystery twist', 220.00, 'https://example.com/images/spicy_nachos_surprise.jpg', 1),
(11, 'Fusion Tacos', 'A new taco creation every day', 230.00, 'https://example.com/images/fusion_tacos.jpg', 1),
(11, 'Experimental Shake', 'A new shake flavor to surprise your taste buds', 180.00, 'https://example.com/images/experimental_shake.jpg', 1),
(11, 'Sweet & Spicy Popcorn', 'Caramel popcorn with a hint of spice', 150.00, 'https://example.com/images/sweet_spicy_popcorn.jpg', 1),
(11, 'Gourmet Wrap', 'A wrap with chef’s secret ingredients', 240.00, 'https://example.com/images/gourmet_wrap.jpg', 1),
(11, 'Surprise Brownie', 'A brownie with a special filling', 170.00, 'https://example.com/images/surprise_brownie.jpg', 1),
(11, 'Mysterious Dessert', 'A sweet treat with unknown flavors', 200.00, 'https://example.com/images/mysterious_dessert.jpg', 1),
(11, 'Secret Beverage', 'A drink specially created by the chef', 190.00, 'https://example.com/images/secret_beverage.jpg', 1);

-- Coolers (Category 12)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(12, 'Lemon Mint Cooler', 'Refreshing lemonade with mint leaves', 120.00, 'https://example.com/images/lemon_mint_cooler.jpg', 1),
(12, 'Blue Lagoon', 'Chilled blue curacao mocktail', 140.00, 'https://example.com/images/blue_lagoon.jpg', 1),
(12, 'Virgin Mojito', 'Lime, mint, and soda refreshment', 160.00, 'https://example.com/images/virgin_mojito.jpg', 1),
(12, 'Aam Panna', 'Raw mango cooler with Indian spices', 130.00, 'https://example.com/images/aam_panna.jpg', 1),
(12, 'Berry Cooler', 'Mixed berry infused chilled drink', 150.00, 'https://example.com/images/berry_cooler.jpg', 1),
(12, 'Orange Basil Cooler', 'Tangy orange with fresh basil', 170.00, 'https://example.com/images/orange_basil_cooler.jpg', 1),
(12, 'Pineapple Punch', 'Pineapple juice with a citrus twist', 180.00, 'https://example.com/images/pineapple_punch.jpg', 1),
(12, 'Watermelon Refresher', 'Cool and hydrating watermelon drink', 140.00, 'https://example.com/images/watermelon_refresher.jpg', 1),
(12, 'Coconut Cooler', 'Tender coconut water with a cooling effect', 190.00, 'https://example.com/images/coconut_cooler.jpg', 1),
(12, 'Cucumber Lime Splash', 'Cool cucumber and zesty lime', 160.00, 'https://example.com/images/cucumber_lime_splash.jpg', 1);

-- Smoothies (Category 13)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(13, 'Mango Smoothie', 'Thick mango smoothie with yogurt', 180.00, 'https://example.com/images/mango_smoothie.jpg', 1),
(13, 'Banana Berry Blast', 'Banana smoothie with mixed berries', 190.00, 'https://example.com/images/banana_berry_blast.jpg', 1),
(13, 'Chocolate Peanut Butter', 'Chocolate smoothie with peanut butter', 210.00, 'https://example.com/images/chocolate_peanut_butter_smoothie.jpg', 1),
(13, 'Avocado Delight', 'Creamy avocado smoothie with honey', 230.00, 'https://example.com/images/avocado_delight.jpg', 1),
(13, 'Strawberry Banana', 'Classic strawberry and banana blend', 200.00, 'https://example.com/images/strawberry_banana_smoothie.jpg', 1),
(13, 'Pineapple Coconut', 'Tropical smoothie with coconut and pineapple', 220.00, 'https://example.com/images/pineapple_coconut_smoothie.jpg', 1),
(13, 'Blueberry Almond', 'Blueberry smoothie with almond milk', 240.00, 'https://example.com/images/blueberry_almond_smoothie.jpg', 1),
(13, 'Green Detox', 'Spinach, banana, and apple smoothie', 210.00, 'https://example.com/images/green_detox_smoothie.jpg', 1),
(13, 'Vanilla Chia Shake', 'Vanilla smoothie with chia seeds', 220.00, 'https://example.com/images/vanilla_chia_shake.jpg', 1),
(13, 'Raspberry Yogurt', 'Tart raspberry smoothie with yogurt', 250.00, 'https://example.com/images/raspberry_yogurt_smoothie.jpg', 1);

INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(14, 'Chocolate Shake', 'Thick and creamy chocolate milkshake', 180.00, 'https://images.unsplash.com/photo-1606756777436-91c2015b3d94', 1),
(14, 'Vanilla Shake', 'Classic vanilla-flavored shake', 160.00, 'https://images.unsplash.com/photo-1572441712894-1c2f50c72033', 1),
(14, 'Strawberry Shake', 'Fresh strawberry blended shake', 170.00, 'https://images.unsplash.com/photo-1599785209794-846ceb5a4b24', 1),
(14, 'Oreo Shake', 'Blended Oreo shake with cream', 190.00, 'https://images.unsplash.com/photo-1514846326710-096e4a8035e7', 1),
(14, 'KitKat Shake', 'Chocolate shake with crushed KitKat', 200.00, 'https://images.unsplash.com/photo-1628843215994-3ae11f75dadd', 1),
(14, 'Cold Coffee Shake', 'Coffee-infused milkshake', 220.00, 'https://images.unsplash.com/photo-1608571423632-b7cc9d0dd91e', 1),
(14, 'Caramel Shake', 'Rich caramel flavored shake', 230.00, 'https://images.unsplash.com/photo-1533134242443-d4fd215305ad', 1),
(14, 'Nutella Shake', 'Nutella blended shake with milk', 250.00, 'https://images.unsplash.com/photo-1576515416547-2315e31f49a3', 1),
(14, 'Banana Shake', 'Sweet banana-flavored shake', 170.00, 'https://images.unsplash.com/photo-1596560548465-7b1cf2c00a04', 1),
(14, 'Biscoff Shake', 'Biscoff-flavored milkshake', 260.00, 'https://images.unsplash.com/photo-1601314165404-006f9829e163', 1);

INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(15, 'Paneer Tikka Wrap', 'Grilled paneer wrapped in a tortilla', 220.00, 'https://images.unsplash.com/photo-1630547038751-21e1d91880a8', 1),
(15, 'Chicken Seekh Wrap', 'Juicy chicken seekh kebab in a wrap', 240.00, 'https://images.unsplash.com/photo-1617977837201-74db6db0c1ba', 1),
(15, 'Falafel Wrap', 'Crispy falafel wrapped in pita bread', 200.00, 'https://images.unsplash.com/photo-1628165567640-09b97f7e4ea3', 1),
(15, 'Hummus Veg Wrap', 'Fresh veggies with hummus in a wrap', 190.00, 'https://images.unsplash.com/photo-1604909053643-10c23d0a1a4d', 1),
(15, 'BBQ Chicken Wrap', 'Smoky BBQ chicken wrapped with lettuce', 250.00, 'https://images.unsplash.com/photo-1593821916372-c08356b808e0', 1),
(15, 'Spicy Mexican Wrap', 'Zesty Mexican-flavored wrap', 230.00, 'https://images.unsplash.com/photo-1630547002730-1333d595a135', 1),
(15, 'Egg & Cheese Wrap', 'Scrambled eggs with cheese', 210.00, 'https://images.unsplash.com/photo-1541099649105-f69ad21f3246', 1),
(15, 'Tandoori Veg Wrap', 'Tandoori-flavored veggies in a wrap', 200.00, 'https://images.unsplash.com/photo-1646745435934-038e7f2a0a90', 1),
(15, 'Mediterranean Wrap', 'Greek-style wrap with olives and feta', 270.00, 'https://images.unsplash.com/photo-1609770423697-1bafbf4bf77e', 1),
(15, 'Cheesy Mushroom Wrap', 'Creamy mushrooms and cheese wrap', 220.00, 'https://images.unsplash.com/photo-1606787366850-de6330128bfc', 1);

-- Wraps (Category 15)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(15, 'Paneer Tikka Wrap', 'Grilled paneer wrapped in a tortilla', 220.00, 'httpsd://example.com/images/paneer_tikka_wrap.jpg', 1),
(15, 'Chicken Seekh Wrap', 'Juicy chicken seekh kebab in a wrap', 240.00, 'httpsd://example.com/images/chicken_seekh_wrap.jpg', 1),
(15, 'Falafel Wrap', 'Crispy falafel wrapped in pita bread', 200.00, 'httpsd://example.com/images/falafel_wrap.jpg', 1),
(15, 'Hummus Veg Wrap', 'Fresh veggies with hummus in a wrap', 190.00, 'httpsd://example.com/images/hummus_veg_wrap.jpg', 1),
(15, 'BBQ Chicken Wrap', 'Smoky BBQ chicken wrapped with lettuce', 250.00, 'httpsd://example.com/images/bbq_chicken_wrap.jpg', 1),
(15, 'Spicy Mexican Wrap', 'Zesty Mexican-flavored wrap', 230.00, 'httpsd://example.com/images/mexican_wrap.jpg', 1),
(15, 'Egg & Cheese Wrap', 'Scrambled eggs with cheese', 210.00, 'httpsd://example.com/images/egg_cheese_wrap.jpg', 1),
(15, 'Tandoori Veg Wrap', 'Tandoori-flavored veggies in a wrap', 200.00, 'httpsd://example.com/images/tandoori_veg_wrap.jpg', 1),
(15, 'Mediterranean Wrap', 'Greek-style wrap with olives and feta', 270.00, 'httpsd://example.com/images/mediterranean_wrap.jpg', 1),
(15, 'Cheesy Mushroom Wrap', 'Creamy mushrooms and cheese wrap', 220.00, 'httpsd://example.com/images/cheesy_mushroom_wrap.jpg', 1);

-- Maggie (Category 16)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(16, 'Classic Maggie', 'Simple and tasty instant noodles', 120.00, 'httpsd://example.com/images/classic_maggie.jpg', 1),
(16, 'Masala Maggie', 'Spicy and flavorful masala maggie', 140.00, 'httpsd://example.com/images/masala_maggie.jpg', 1),
(16, 'Cheese Maggie', 'Creamy maggie with melted cheese', 150.00, 'httpsd://example.com/images/cheese_maggie.jpg', 1),
(16, 'Butter Maggie', 'Buttery soft maggie noodles', 130.00, 'httpsd://example.com/images/butter_maggie.jpg', 1),
(16, 'Paneer Bhurji Maggie', 'Scrambled paneer mixed with maggie', 180.00, 'httpsd://example.com/images/paneer_bhurji_maggie.jpg', 1),
(16, 'Egg Maggie', 'Egg-infused maggie for extra protein', 170.00, 'httpsd://example.com/images/egg_maggie.jpg', 1),
(16, 'Tandoori Maggie', 'Smoky tandoori-flavored maggie', 190.00, 'httpsd://example.com/images/tandoori_maggie.jpg', 1),
(16, 'Schezwan Maggie', 'Spicy Schezwan maggie noodles', 160.00, 'httpsd://example.com/images/schezwan_maggie.jpg', 1),
(16, 'Veggie Delight Maggie', 'Loaded with fresh vegetables', 175.00, 'httpsd://example.com/images/veggie_maggie.jpg', 1),
(16, 'Corn & Cheese Maggie', 'Sweet corn with creamy cheese maggie', 190.00, 'httpsd://example.com/images/corn_cheese_maggie.jpg', 1);

-- Burger (Category 17)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(17, 'Classic Veg Burger', 'Crispy veg patty with lettuce and mayo', 180.00, 'httpsd://example.com/images/veg_burger.jpg', 1),
(17, 'Cheese Burger', 'Classic burger with extra cheese', 190.00, 'httpsd://example.com/images/cheese_burger.jpg', 1),
(17, 'Paneer Burger', 'Paneer patty with Indian spices', 200.00, 'httpsd://example.com/images/paneer_burger.jpg', 1),
(17, 'Grilled Chicken Burger', 'Juicy grilled chicken burger', 220.00, 'httpsd://example.com/images/grilled_chicken_burger.jpg', 1),
(17, 'Spicy Peri Peri Burger', 'Burger with spicy peri peri sauce', 230.00, 'httpsd://example.com/images/peri_peri_burger.jpg', 1),
(17, 'BBQ Chicken Burger', 'BBQ flavored grilled chicken burger', 250.00, 'httpsd://example.com/images/bbq_chicken_burger.jpg', 1),
(17, 'Double Patty Burger', 'Two layers of patties for extra taste', 260.00, 'httpsd://example.com/images/double_patty_burger.jpg', 1),
(17, 'Egg Burger', 'Egg omelet in a soft bun', 170.00, 'httpsd://example.com/images/egg_burger.jpg', 1),
(17, 'Crispy Chicken Burger', 'Crispy fried chicken with mayo', 240.00, 'httpsd://example.com/images/crispy_chicken_burger.jpg', 1),
(17, 'Tandoori Chicken Burger', 'Smoky tandoori chicken patty burger', 270.00, 'httpsd://example.com/images/tandoori_chicken_burger.jpg', 1);

-- Coffee (Category 18)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(18, 'Espresso', 'Strong and bold coffee shot', 120.00, 'httpsd://example.com/images/espresso.jpg', 1),
(18, 'Cappuccino', 'Creamy coffee with frothy milk', 150.00, 'httpsd://example.com/images/cappuccino.jpg', 1),
(18, 'Latte', 'Smooth and milky coffee', 160.00, 'httpsd://example.com/images/latte.jpg', 1),
(18, 'Mocha', 'Chocolate-infused coffee delight', 180.00, 'httpsd://example.com/images/mocha.jpg', 1),
(18, 'Caramel Macchiato', 'Sweet caramel espresso drink', 200.00, 'httpsd://example.com/images/caramel_macchiato.jpg', 1),
(18, 'Americano', 'Classic black coffee', 140.00, 'httpsd://example.com/images/americano.jpg', 1),
(18, 'Hazelnut Coffee', 'Nutty flavored coffee', 170.00, 'httpsd://example.com/images/hazelnut_coffee.jpg', 1),
(18, 'Irish Coffee', 'Coffee with whipped cream and syrup', 220.00, 'httpsd://example.com/images/irish_coffee.jpg', 1),
(18, 'Turkish Coffee', 'Strong Turkish-style coffee', 240.00, 'httpsd://example.com/images/turkish_coffee.jpg', 1),
(18, 'Filter Coffee', 'Traditional South Indian coffee', 160.00, 'httpsd://example.com/images/filter_coffee.jpg', 1);

-- Soda (Category 19)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(19, 'Coke', 'Classic Coca-Cola', 80.00, 'httpsd://example.com/images/coke.jpg', 1),
(19, 'Pepsi', 'Refreshing cola', 80.00, 'httpsd://example.com/images/pepsi.jpg', 1),
(19, 'Sprite', 'Lemon-lime soda', 80.00, 'httpsd://example.com/images/sprite.jpg', 1),
(19, 'Fanta', 'Tangy orange soda', 90.00, 'httpsd://example.com/images/fanta.jpg', 1),
(19, 'Mountain Dew', 'Citrus-flavored soda', 100.00, 'httpsd://example.com/images/mountain_dew.jpg', 1);

-- Live Shots (Category 20)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(20, 'Lemon Shot', 'Tangy lemon shot for a refreshing kick', 90.00, 'httpsd://example.com/images/lemon_shot.jpg', 1),
(20, 'Berry Blast Shot', 'Sweet and sour berry-flavored shot', 100.00, 'httpsd://example.com/images/berry_blast_shot.jpg', 1),
(20, 'Mint Mojito Shot', 'Mini mint mojito for a fresh burst', 110.00, 'httpsd://example.com/images/mint_mojito_shot.jpg', 1),
(20, 'Ginger Spice Shot', 'Zesty ginger-infused shot', 120.00, 'httpsd://example.com/images/ginger_spice_shot.jpg', 1),
(20, 'Honey Lime Shot', 'Sweet and sour honey lime shot', 130.00, 'httpsd://example.com/images/honey_lime_shot.jpg', 1),
(20, 'Coconut Surprise Shot', 'Tropical coconut-flavored shot', 140.00, 'httpsd://example.com/images/coconut_surprise_shot.jpg', 1),
(20, 'Tamarind Shot', 'Sour and tangy tamarind-based shot', 110.00, 'httpsd://example.com/images/tamarind_shot.jpg', 1),
(20, 'Mango Tango Shot', 'Mango-based energetic drink', 120.00, 'httpsd://example.com/images/mango_tango_shot.jpg', 1),
(20, 'Pineapple Punch Shot', 'Sweet and tangy pineapple drink', 130.00, 'httpsd://example.com/images/pineapple_punch_shot.jpg', 1),
(20, 'Watermelon Chill Shot', 'Cool and refreshing watermelon drink', 120.00, 'httpsd://example.com/images/watermelon_chill_shot.jpg', 1);

-- Hot Tea (Category 21)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(21, 'Masala Chai', 'Traditional Indian spiced tea', 80.00, 'httpsd://example.com/images/masala_chai.jpg', 1),
(21, 'Ginger Tea', 'Strong tea infused with fresh ginger', 90.00, 'httpsd://example.com/images/ginger_tea.jpg', 1),
(21, 'Cardamom Tea', 'Flavored with aromatic cardamom', 100.00, 'httpsd://example.com/images/cardamom_tea.jpg', 1),
(21, 'Lemon Honey Tea', 'Refreshing lemon tea with honey', 110.00, 'httpsd://example.com/images/lemon_honey_tea.jpg', 1),
(21, 'Green Tea', 'Healthy green tea with antioxidants', 120.00, 'httpsd://example.com/images/green_tea.jpg', 1),
(21, 'Black Tea', 'Classic plain black tea', 85.00, 'httpsd://example.com/images/black_tea.jpg', 1),
(21, 'Tulsi Tea', 'Herbal tea infused with tulsi leaves', 90.00, 'httpsd://example.com/images/tulsi_tea.jpg', 1),
(21, 'Jasmine Tea', 'Fragrant jasmine-infused tea', 130.00, 'httpsd://example.com/images/jasmine_tea.jpg', 1),
(21, 'Chamomile Tea', 'Relaxing herbal chamomile tea', 140.00, 'httpsd://example.com/images/chamomile_tea.jpg', 1),
(21, 'Saffron Tea', 'Rich saffron-flavored tea', 150.00, 'httpsd://example.com/images/saffron_tea.jpg', 1);

-- Chinese (Category 22)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(22, 'Veg Hakka Noodles', 'Stir-fried noodles with veggies', 180.00, 'httpsd://example.com/images/veg_hakka_noodles.jpg', 1),
(22, 'Chicken Manchurian', 'Spicy and tangy chicken dish', 220.00, 'httpsd://example.com/images/chicken_manchurian.jpg', 1),
(22, 'Chili Paneer', 'Paneer tossed in spicy chili sauce', 210.00, 'httpsd://example.com/images/chili_paneer.jpg', 1),
(22, 'Schezwan Fried Rice', 'Spicy Schezwan-style fried rice', 200.00, 'httpsd://example.com/images/schezwan_fried_rice.jpg', 1),
(22, 'Spring Rolls', 'Crispy fried rolls with veggie filling', 160.00, 'httpsd://example.com/images/spring_rolls.jpg', 1),
(22, 'Chowmein', 'Classic Indo-Chinese style noodles', 190.00, 'httpsd://example.com/images/chowmein.jpg', 1),
(22, 'Honey Chili Potato', 'Crispy potato tossed in honey chili sauce', 180.00, 'httpsd://example.com/images/honey_chili_potato.jpg', 1),
(22, 'Crispy Fried Chicken', 'Golden crispy fried chicken', 230.00, 'httpsd://example.com/images/crispy_fried_chicken.jpg', 1),
(22, 'Dim Sums', 'Steamed dumplings with veg/chicken filling', 200.00, 'httpsd://example.com/images/dim_sums.jpg', 1),
(22, 'Hot & Sour Soup', 'Tangy and spicy Chinese soup', 150.00, 'httpsd://example.com/images/hot_sour_soup.jpg', 1);

-- Rice Bowls (Category 23)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(23, 'Teriyaki Chicken Bowl', 'Chicken in teriyaki sauce over rice', 250.00, 'httpsd://example.com/images/teriyaki_chicken_bowl.jpg', 1),
(23, 'Veg Stir Fry Bowl', 'Mixed veggies stir-fried with rice', 200.00, 'httpsd://example.com/images/veg_stir_fry_bowl.jpg', 1),
(23, 'Butter Chicken Bowl', 'Butter chicken served over rice', 280.00, 'httpsd://example.com/images/butter_chicken_bowl.jpg', 1),
(23, 'Paneer Tikka Rice Bowl', 'Grilled paneer served over rice', 240.00, 'httpsd://example.com/images/paneer_tikka_rice_bowl.jpg', 1),
(23, 'Thai Green Curry Bowl', 'Thai curry served with jasmine rice', 270.00, 'httpsd://example.com/images/thai_green_curry_bowl.jpg', 1),
(23, 'Dal Tadka Rice Bowl', 'Classic dal tadka served with rice', 190.00, 'httpsd://example.com/images/dal_tadka_rice_bowl.jpg', 1),
(23, 'Egg Fried Rice Bowl', 'Egg and rice stir-fried with sauces', 220.00, 'httpsd://example.com/images/egg_fried_rice_bowl.jpg', 1),
(23, 'Tandoori Chicken Rice Bowl', 'Tandoori chicken with flavored rice', 290.00, 'httpsd://example.com/images/tandoori_chicken_rice_bowl.jpg', 1),
(23, 'Mushroom Pepper Rice Bowl', 'Mushrooms in black pepper sauce over rice', 260.00, 'httpsd://example.com/images/mushroom_pepper_rice_bowl.jpg', 1),
(23, 'Schezwan Rice Bowl', 'Spicy Schezwan rice with veggies', 230.00, 'httpsd://example.com/images/schezwan_rice_bowl.jpg', 1);


-- Tandoori Fresh (Category 24)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(24, 'Tandoori Chicken', 'Juicy chicken marinated with spices and grilled in a tandoor', 350.00, 'httpsd://example.com/images/tandoori_chicken.jpg', 1),
(24, 'Paneer Tikka', 'Grilled paneer cubes marinated with special spices', 280.00, 'httpsd://example.com/images/paneer_tikka.jpg', 1),
(24, 'Tandoori Prawns', 'Succulent prawns grilled with smoky flavors', 400.00, 'httpsd://example.com/images/tandoori_prawns.jpg', 1),
(24, 'Malai Chicken Tikka', 'Creamy and flavorful tandoori chicken', 360.00, 'httpsd://example.com/images/malai_chicken_tikka.jpg', 1),
(24, 'Tandoori Mushroom', 'Mushrooms grilled with yogurt-based marination', 290.00, 'httpsd://example.com/images/tandoori_mushroom.jpg', 1),
(24, 'Fish Tikka', 'Grilled fish with aromatic Indian spices', 380.00, 'httpsd://example.com/images/fish_tikka.jpg', 1),
(24, 'Tandoori Aloo', 'Spicy and smoky baby potatoes', 260.00, 'httpsd://example.com/images/tandoori_aloo.jpg', 1),
(24, 'Mutton Seekh Kebab', 'Juicy minced mutton kebabs', 420.00, 'httpsd://example.com/images/mutton_seekh_kebab.jpg', 1),
(24, 'Chicken Seekh Kebab', 'Tender minced chicken skewers', 380.00, 'httpsd://example.com/images/chicken_seekh_kebab.jpg', 1),
(24, 'Tandoori Phool', 'Cauliflower grilled in tandoori masala', 270.00, 'httpsd://example.com/images/tandoori_phool.jpg', 1);

-- Paratha (Category 25)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(25, 'Aloo Paratha', 'Stuffed with spicy mashed potatoes', 120.00, 'httpsd://example.com/images/aloo_paratha.jpg', 1),
(25, 'Paneer Paratha', 'Filled with soft paneer stuffing', 140.00, 'httpsd://example.com/images/paneer_paratha.jpg', 1),
(25, 'Methi Paratha', 'Infused with fresh fenugreek leaves', 110.00, 'httpsd://example.com/images/methi_paratha.jpg', 1),
(25, 'Gobi Paratha', 'Stuffed with spicy grated cauliflower', 130.00, 'httpsd://example.com/images/gobi_paratha.jpg', 1),
(25, 'Cheese Paratha', 'Melted cheese stuffed paratha', 160.00, 'httpsd://example.com/images/cheese_paratha.jpg', 1),
(25, 'Mutton Keema Paratha', 'Stuffed with flavorful minced mutton', 250.00, 'httpsd://example.com/images/mutton_keema_paratha.jpg', 1),
(25, 'Egg Paratha', 'Omelette stuffed inside crispy paratha', 180.00, 'httpsd://example.com/images/egg_paratha.jpg', 1),
(25, 'Onion Paratha', 'Flavored with spiced onions', 125.00, 'httpsd://example.com/images/onion_paratha.jpg', 1),
(25, 'Mix Veg Paratha', 'Loaded with a mix of vegetables', 150.00, 'httpsd://example.com/images/mix_veg_paratha.jpg', 1),
(25, 'Ajwain Paratha', 'Flavored with carom seeds', 100.00, 'httpsd://example.com/images/ajwain_paratha.jpg', 1);

-- Sizzler (Category 26)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(26, 'Veg Sizzler', 'Grilled vegetables served with rice and sauce', 400.00, 'httpsd://example.com/images/veg_sizzler.jpg', 1),
(26, 'Paneer Sizzler', 'Grilled paneer with smoky sauce', 450.00, 'httpsd://example.com/images/paneer_sizzler.jpg', 1),
(26, 'Chicken Sizzler', 'Grilled chicken with spicy sauce', 500.00, 'httpsd://example.com/images/chicken_sizzler.jpg', 1),
(26, 'Mushroom Sizzler', 'Mushrooms cooked with grilled veggies', 420.00, 'httpsd://example.com/images/mushroom_sizzler.jpg', 1),
(26, 'Seafood Sizzler', 'Prawns and fish grilled with sauces', 600.00, 'httpsd://example.com/images/seafood_sizzler.jpg', 1),
(26, 'Mutton Sizzler', 'Mutton steaks grilled to perfection', 550.00, 'httpsd://example.com/images/mutton_sizzler.jpg', 1),
(26, 'Tandoori Sizzler', 'Tandoori grilled items served sizzling hot', 480.00, 'httpsd://example.com/images/tandoori_sizzler.jpg', 1),
(26, 'Spaghetti Sizzler', 'Spaghetti with grilled veggies', 460.00, 'httpsd://example.com/images/spaghetti_sizzler.jpg', 1),
(26, 'Cheese Sizzler', 'Loaded with cheese and grilled veggies', 430.00, 'httpsd://example.com/images/cheese_sizzler.jpg', 1),
(26, 'Mixed Grill Sizzler', 'Assorted grilled meats and veggies', 520.00, 'httpsd://example.com/images/mixed_grill_sizzler.jpg', 1);

-- Roti (Category 27)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(27, 'Butter Roti', 'Soft whole wheat roti with butter', 50.00, 'httpsd://example.com/images/butter_roti.jpg', 1),
(27, 'Tandoori Roti', 'Crispy roti cooked in tandoor', 60.00, 'httpsd://example.com/images/tandoori_roti.jpg', 1),
(27, 'Missi Roti', 'Gram flour roti with spices', 70.00, 'httpsd://example.com/images/missi_roti.jpg', 1),
(27, 'Laccha Paratha', 'Layered crispy paratha', 90.00, 'httpsd://example.com/images/laccha_paratha.jpg', 1),
(27, 'Naan', 'Soft, fluffy Indian bread', 80.00, 'httpsd://example.com/images/naan.jpg', 1),
(27, 'Garlic Naan', 'Flavored naan with garlic butter', 100.00, 'httpsd://example.com/images/garlic_naan.jpg', 1),
(27, 'Stuffed Kulcha', 'Soft bread stuffed with masala filling', 120.00, 'httpsd://example.com/images/stuffed_kulcha.jpg', 1),
(27, 'Phulka', 'Soft homemade chapati', 50.00, 'httpsd://example.com/images/phulka.jpg', 1),
(27, 'Roomali Roti', 'Thin and soft Indian bread', 70.00, 'httpsd://example.com/images/roomali_roti.jpg', 1),
(27, 'Cheese Naan', 'Naan stuffed with melted cheese', 130.00, 'httpsd://example.com/images/cheese_naan.jpg', 1);

-- Main Course (Category 28)
INSERT INTO Menu (Category_Id, Name, Description, Price, Image_Url, Availability)
VALUES
(28, 'Butter Chicken', 'Creamy tomato-based chicken curry', 380.00, 'httpsd://example.com/images/butter_chicken.jpg', 1),
(28, 'Paneer Butter Masala', 'Paneer cooked in a rich buttery tomato sauce', 340.00, 'httpsd://example.com/images/paneer_butter_masala.jpg', 1),
(28, 'Dal Makhani', 'Slow-cooked black lentils in creamy gravy', 290.00, 'httpsd://example.com/images/dal_makhani.jpg', 1),
(28, 'Kadhai Chicken', 'Spicy chicken cooked with bell peppers', 370.00, 'httpsd://example.com/images/kadhai_chicken.jpg', 1),
(28, 'Mutton Rogan Josh', 'Flavorful Kashmiri-style mutton curry', 450.00, 'httpsd://example.com/images/mutton_rogan_josh.jpg', 1),
(28, 'Mix Veg Curry', 'Assorted vegetables cooked in a rich curry', 300.00, 'httpsd://example.com/images/mix_veg_curry.jpg', 1),
(28, 'Chole Bhature', 'Spicy chickpeas served with fluffy bhature', 250.00, 'httpsd://example.com/images/chole_bhature.jpg', 1),
(28, 'Palak Paneer', 'Paneer cubes in a creamy spinach gravy', 330.00, 'httpsd://example.com/images/palak_paneer.jpg', 1),
(28, 'Chicken Handi', 'Traditional chicken curry slow-cooked in a clay pot', 390.00, 'httpsd://example.com/images/chicken_handi.jpg', 1),
(28, 'Aloo Gobi Masala', 'Potatoes and cauliflower cooked with spices', 280.00, 'httpsd://example.com/images/aloo_gobi.jpg', 1);




 -----------------------------------------------------------------------------------------------------------------

 INSERT INTO Tables (Table_Number, Capacity, Status, Location) 
VALUES
    (1, 2, 'available', 'Inside Hall - Near Entrance'),
    (2, 4, 'available', 'Inside Hall - Center'),
    (3, 6, 'available', 'Rooftop - Corner'),
    (4, 2, 'available', 'Inside Hall - Near Window'),
    (5, 4, 'available', 'Inside Hall - Side Area'),
    (6, 8, 'available', 'Rooftop - Open Area'),
    (7, 6, 'available', 'Rooftop - Lounge Section'),
    (8, 2, 'available', 'Inside Hall - Near Bar'),
    (9, 4, 'available', 'Inside Hall - Private Booth'),
    (10, 8, 'available', 'Rooftop - VIP Section'),
    (11, 2, 'available', 'Inside Hall - Near Stage'),
    (12, 4, 'available', 'Inside Hall - Family Section'),
    (13, 6, 'available', 'Rooftop - Terrace View'),
    (14, 4, 'available', 'Rooftop - Near Garden'),
    (15, 8, 'available', 'Rooftop - Sunset View');
 
 ---------------------------------------------------------

 INSERT INTO Users (Name, Email, Password, Role, Phone, Created_At)
VALUES
    ('Pratham Modi', 'Pratham@gmail.com', 'Admin@123', 'admin', '9876543210', GETDATE()),

    ('Darshan', 'Darshan@gmail.com', 'Waiter@123', 'waiter', '9876543211', GETDATE()),
    ('Krutarth', 'Krutarth@gmail.com', 'Waiter@123', 'waiter', '9876543212', GETDATE()),
    ('Jayesh', 'Jayesh@gmail.com', 'Waiter@123', 'waiter', '9876543213', GETDATE()),
    ('Rahin', 'Rahin@gmail.com', 'Waiter@123', 'waiter', '9876543214', GETDATE()),

    ('Rachit ', 'Rachit@gmail.com', 'Chef@123', 'chef', '9876543215', GETDATE()),
    ('Sahil', 'Sahil@gmail.com', 'Chef@123', 'chef', '9876543216', GETDATE()),

    ('Apurva', 'Apurva@gmail.com', 'Cashier@123', 'cashier', '9876543217', GETDATE()),
    ('Vrushank', 'Vrushank@gmail.com', 'Cashier@123', 'cashier', '9876543218', GETDATE());

------------------------------------------------------------------------------------------------

INSERT INTO Suppliers (Name, Contact, Email, Address) VALUES
-- Grocery Suppliers
('Shree Ram Grocery', '0261-2345671', 'shreeramgrocery@gmail.com', '10 Market Road, Surat, Gujarat, 395001'),
('Jain Super Mart', '0261-2345672', 'jainsupermart@gmail.com', '15 Grocery Lane, Surat, Gujarat, 395002'),
('Patel Kirana Store', '0261-2345673', 'patelkirana@gmail.com', '20 Main Bazaar, Surat, Gujarat, 395003'),

-- Dairy Product Suppliers
('Amul Dairy Supplier', '0261-2345674', 'amul@dairy.com', '30 Dairy Street, Surat, Gujarat, 395004'),
('Shakti Dairy', '0261-2345675', 'shaktidairy@gmail.com', '40 Milk Road, Surat, Gujarat, 395005'),
('Surat Fresh Dairy', '0261-2345676', 'suratfreshdairy@gmail.com', '50 Cream Colony, Surat, Gujarat, 395006'),

-- Vegetable Suppliers
('Green Farms Vegetables', '0261-2345677', 'greenfarms@gmail.com', '60 Farm Market, Surat, Gujarat, 395007'),
('Surat Fresh Vegetables', '0261-2345678', 'suratfreshveg@gmail.com', '70 Veg Plaza, Surat, Gujarat, 395008'),
('Organic Veggies', '0261-2345679', 'organicveggies@gmail.com', '80 Healthy Market, Surat, Gujarat, 395009'),

-- Non-Vegetarian Suppliers
('Surat Meat Center', '0261-2345680', 'meatcenter@gmail.com', '90 Butcher Street, Surat, Gujarat, 395010'),
('Fresh Chicken & Fish', '0261-2345681', 'freshchickenfish@gmail.com', '100 Seafood Lane, Surat, Gujarat, 395011'),
('Royal Poultry', '0261-2345682', 'royalpoultry@gmail.com', '110 Poultry Avenue, Surat, Gujarat, 395012'),

-- Other Restaurant Essentials Suppliers
('Kitchen Essentials Surat', '0261-2345683', 'kitchenessentials@gmail.com', '120 Chef Market, Surat, Gujarat, 395013'),
('Hotel & Catering Supplies', '0261-2345684', 'hotelsupplies@gmail.com', '130 Restaurant Street, Surat, Gujarat, 395014'),
('Eco-Packaging Solutions', '0261-2345685', 'ecopackaging@gmail.com', '140 Greenway Road, Surat, Gujarat, 395015');

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Inventory (ProductName, Quantity, Price, Supplier_ID, LastUpdated) 
VALUES
-- Shree Ram Grocery (2)
('Wheat Flour', 100, 45.50, 2, GETDATE()),
('Basmati Rice', 50, 120.00, 2, GETDATE()),
('Cooking Oil', 80, 150.00, 2, GETDATE()),
('Sugar', 90, 40.00, 2, GETDATE()),
('Salt', 200, 20.00, 2, GETDATE()),

-- Jain Super Mart (3)
('Milk Powder', 120, 250.00, 3, GETDATE()),
('Tea Leaves', 80, 180.00, 3, GETDATE()),
('Coffee', 60, 220.00, 3, GETDATE()),
('Biscuits', 150, 30.00, 3, GETDATE()),
('Cooking Spices', 90, 90.00, 3, GETDATE()),

-- Patel Kirana Store (4)
('Lentils', 130, 110.00, 4, GETDATE()),
('Rice Bran Oil', 70, 140.00, 4, GETDATE()),
('Whole Wheat', 90, 55.00, 4, GETDATE()),
('Dry Fruits', 60, 350.00, 4, GETDATE()),
('Salted Snacks', 100, 50.00, 4, GETDATE()),

-- Amul Dairy Supplier (5)
('Milk', 200, 55.00, 5, GETDATE()),
('Paneer', 180, 90.00, 5, GETDATE()),
('Cheese', 220, 80.00, 5, GETDATE()),
('Butter', 150, 50.00, 5, GETDATE()),
('Ghee', 120, 500.00, 5, GETDATE()),

-- Shakti Dairy (6)
('Full Cream Milk', 200, 55.00, 6, GETDATE()),
('Skimmed Milk', 180, 50.00, 6, GETDATE()),
('Curd', 220, 45.00, 6, GETDATE()),
('Lassi', 150, 35.00, 6, GETDATE()),
('Flavored Milk', 130, 40.00, 6, GETDATE()),

-- Surat Fresh Dairy (7)
('Toned Milk', 190, 48.00, 7, GETDATE()),
('Butter Milk', 180, 30.00, 7, GETDATE()),
('Dahi', 220, 42.00, 7, GETDATE()),
('Khoa', 160, 110.00, 7, GETDATE()),
('Milkshake', 140, 70.00, 7, GETDATE()),

-- Green Farms Vegetables (8)
('Fresh Lettuce', 160, 40.00, 8, GETDATE()),
('Cucumber', 200, 30.00, 8, GETDATE()),
('Bell Peppers', 140, 70.00, 8, GETDATE()),
('Brinjals', 180, 25.00, 8, GETDATE()),
('Cauliflower', 190, 45.00, 8, GETDATE()),

-- Surat Fresh Vegetables (9)
('Tomatoes', 180, 32.00, 9, GETDATE()),
('Carrots', 190, 38.00, 9, GETDATE()),
('Onions', 210, 28.00, 9, GETDATE()),
('Garlic', 130, 90.00, 9, GETDATE()),
('Ginger', 120, 95.00, 9, GETDATE()),

-- Organic Veggies (10)
('Organic Spinach', 170, 25.00, 10, GETDATE()),
('Organic Broccoli', 160, 55.00, 10, GETDATE()),
('Organic Beans', 140, 65.00, 10, GETDATE()),
('Organic Capsicum', 130, 75.00, 10, GETDATE()),
('Organic Carrots', 120, 45.00, 10, GETDATE()),

-- Surat Meat Center (11)
('Chicken Breast', 90, 220.00, 11, GETDATE()),
('Mutton', 70, 450.00, 11, GETDATE()),
('Fresh Fish', 80, 300.00, 11, GETDATE()),
('Prawns', 60, 400.00, 11, GETDATE()),
('Eggs', 500, 6.00, 11, GETDATE()),

-- Fresh Chicken & Fish (12)
('Chicken Wings', 90, 180.00, 12, GETDATE()),
('Chicken Drumsticks', 80, 200.00, 12, GETDATE()),
('Fish Fillet', 70, 320.00, 12, GETDATE()),
('Pork Chops', 60, 400.00, 12, GETDATE()),
('Lamb Meat', 50, 500.00, 12, GETDATE()),

-- Royal Poultry (13)
('Whole Chicken', 90, 210.00, 13, GETDATE()),
('Chicken Liver', 100, 180.00, 13, GETDATE()),
('Chicken Sausages', 70, 250.00, 13, GETDATE()),
('Duck Meat', 60, 550.00, 13, GETDATE()),
('Quail Eggs', 200, 20.00, 13, GETDATE()),

-- Kitchen Essentials Surat (14)
('Baking Trays', 100, 800.00, 14, GETDATE()),
('Chef Knives', 120, 1200.00, 14, GETDATE()),
('Measuring Cups', 150, 300.00, 14, GETDATE()),
('Silicone Spatulas', 200, 150.00, 14, GETDATE()),
('Steel Mixing Bowls', 180, 600.00, 14, GETDATE()),

-- Hotel & Catering Supplies (15)
('Serving Dishes', 100, 700.00, 15, GETDATE()),
('Table Napkins', 200, 50.00, 15, GETDATE()),
('Cutlery Set', 150, 900.00, 15, GETDATE()),
('Buffet Warmers', 80, 3000.00, 15, GETDATE()),
('Glassware Set', 120, 1500.00, 15, GETDATE()),

-- Eco-Packaging Solutions (16)
('Takeaway Boxes', 300, 50.00, 16, GETDATE()),
('Paper Straws', 400, 5.00, 16, GETDATE()),
('Reusable Cups', 250, 100.00, 16, GETDATE()),
('Compostable Bags', 200, 75.00, 16, GETDATE()),
('Eco-Friendly Cutlery', 350, 20.00, 16, GETDATE());


---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Employee_Shifts (User_Id, Shift_Start, Shift_End, Role)
VALUES
    (1, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'admin'),

    (2, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'waiter'),
    (3, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'waiter'),
    (4, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'waiter'),
    (5, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'waiter'),

    (6, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'chef'),
    (7, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'chef'),

    (8, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'cashier'),
    (9, '2025-04-02 09:00:00', '2025-04-02 17:00:00', 'cashier');
------------------------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Discounts (Name, Discount_Type, Value, Start_Date, End_Date)
VALUES
    ('Opening', 'percentage', 20.00, '2025-01-01', '2025-01-31'),  -- 20% Discount
    ('Summer Promotion', 'percentage', 15.00, '2025-06-01', '2025-06-30'), -- 15% Discount
    ('Fixed Price Discount', 'fixed', 50.00, '2025-03-01', '2025-03-31'), -- 50 Fixed Amount Discount
    ('No Discount', 'percentage', 0.00, '2025-12-01', '2025-12-31'), -- 0% Discount (Free)
    ('Special Discount', 'fixed', 100.00, '2025-04-01', '2025-04-30');   -- 100 Fixed Amount Discount

	select*from  Discounts	

----------------------------------------------------------------------------------------------------------------------------------------------
-- More random data for existing categories
INSERT INTO Expenses (Category, Amount, Date, Note) VALUES
('Electricity', 2890.00, DATEADD(DAY, -29, GETDATE()), 'April electricity adjustment'),
('Electricity', 3120.00, DATEADD(DAY, -14, GETDATE()), 'High consumption this week'),

('Rent', 15000.00, DATEADD(DAY, -1, GETDATE()), 'June advance'),
('Rent', 15000.00, DATEADD(DAY, -15, GETDATE()), 'Split rent paid early'),

('Groceries', 1845.25, DATEADD(DAY, -2, GETDATE()), 'Rice, pulses, salt'),
('Groceries', 2300.00, DATEADD(DAY, -11, GETDATE()), 'Snacks & dry items'),

('Staff Salary', 26000.00, DATEADD(DAY, -20, GETDATE()), 'Advance for new joiner'),
('Staff Salary', 26500.00, DATEADD(DAY, -30, GETDATE()), 'Last month final payout'),

('Maintenance', 1900.00, DATEADD(DAY, -16, GETDATE()), 'Fan replacement'),
('Maintenance', 2750.00, DATEADD(DAY, -5, GETDATE()), 'Pipeline leakage repair'),

('Internet', 999.00, DATEADD(DAY, -10, GETDATE()), 'Monthly bill (2nd line)'),

('Cleaning', 1100.00, DATEADD(DAY, -6, GETDATE()), 'Glass cleaner + disinfectant'),

('Transport', 740.00, DATEADD(DAY, -12, GETDATE()), 'Bulk parcel delivery'),
('Transport', 610.00, DATEADD(DAY, -3, GETDATE()), 'Fuel for delivery bike'),

('Marketing', 2100.00, DATEADD(DAY, -7, GETDATE()), 'WhatsApp bulk SMS'),
('Marketing', 2750.00, DATEADD(DAY, -25, GETDATE()), 'In-house poster printing'),

('Bank Charges', 175.00, DATEADD(DAY, -19, GETDATE()), 'Settlement reversal fee'),

('Software Subscription', 1000.00, DATEADD(DAY, -21, GETDATE()), 'Theme customization'),

('Gas Refill', 930.00, DATEADD(DAY, -10, GETDATE()), 'Indane delivery charges'),

('Stationery', 500.00, DATEADD(DAY, -24, GETDATE()), 'Bill books and files'),

('Pest Control', 720.00, DATEADD(DAY, -27, GETDATE()), 'Kitchen & store room service'),

('Water Supply', 520.00, DATEADD(DAY, -4, GETDATE()), '20L x 2 bottles'),

('Uniforms', 1400.00, DATEADD(DAY, -18, GETDATE()), 'Aprons and chef coat'),

('Packaging', 1200.00, DATEADD(DAY, -6, GETDATE()), 'Brown bags + containers'),
('Packaging', 850.00, DATEADD(DAY, -20, GETDATE()), 'Cups + straws'),

('Event Decoration', 1800.00, DATEADD(DAY, -9, GETDATE()), 'Wedding setup decoration'),

('Music License', 1500.00, DATEADD(DAY, -28, GETDATE()), 'Saregama license renewal'),

('Miscellaneous', 280.00, DATEADD(DAY, -13, GETDATE()), 'Instant staff meal expense'),
('Miscellaneous', 400.00, DATEADD(DAY, -22, GETDATE()), 'Power socket repair'),

-- Weekend + special
('Snacks for staff', 320.00, DATEADD(DAY, -1, GETDATE()), 'Ice cream treat'),
('Snacks for staff', 280.00, DATEADD(DAY, -8, GETDATE()), 'Evening samosas'),

('Batteries', 200.00, DATEADD(DAY, -5, GETDATE()), 'AA pack for weighing scale'),

('Menu Printing', 980.00, DATEADD(DAY, -17, GETDATE()), 'Updated branding'),

('Glassware', 1650.00, DATEADD(DAY, -23, GETDATE()), 'Replaced broken set'),

('Courier Charges', 260.00, DATEADD(DAY, -21, GETDATE()), 'Sent back damaged POS');
-- Furniture purchases
INSERT INTO Expenses (Category, Amount, Date, Note) VALUES
('Furniture', 8500.00, DATEADD(DAY, -14, GETDATE()), 'New table & chairs for dining'),
('Furniture', 4200.00, DATEADD(DAY, -26, GETDATE()), 'Cashier desk replacement'),
('Furniture', 6500.00, DATEADD(DAY, -8, GETDATE()), 'Outdoor seating bench'),

-- Kitchen utensils
INSERT INTO Expenses (Category, Amount, Date, Note) VALUES
('Kitchen Utensils', 2700.00, DATEADD(DAY, -9, GETDATE()), 'Stainless steel plates & bowls'),
('Kitchen Utensils', 1450.00, DATEADD(DAY, -20, GETDATE()), 'Tava, Kadai, spatula sets'),
('Kitchen Utensils', 3100.00, DATEADD(DAY, -5, GETDATE()), 'Replacement of broken items'),

-- Storage & Shelving
INSERT INTO Expenses (Category, Amount, Date, Note) VALUES
('Furniture', 3200.00, DATEADD(DAY, -12, GETDATE()), 'Wooden rack for storage'),
('Furniture', 1800.00, DATEADD(DAY, -3, GETDATE()), 'New cutlery drawers'),

-- Kitchen tools or small equipment
INSERT INTO Expenses (Category, Amount, Date, Note) VALUES
('Kitchen Utensils', 2200.00, DATEADD(DAY, -15, GETDATE()), 'Pressure cooker & tongs'),
('Kitchen Utensils', 1650.00, DATEADD(DAY, -7, GETDATE()), 'Knives and cutting boards');
