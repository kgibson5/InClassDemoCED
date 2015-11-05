use eRestaurant
go
drop table RecipeIngredients
drop table Recipes
go
Create Table Recipes
(
RecipeID int identity(1,1) not null 
	Constraint PK_Recipes_RecipesID primary key Clustered,
Instructions varchar(4096) not null,
PrepTime int not null,
ItemID int not null
	Constraint FK_RecipesItems_ItemID 
	REFERENCES Items(ItemID)
)
go
Create Table RecipeIngredients
(
RecipeIngredientID int identity(1,1) not null
	Constraint PK_RecipeIngredients_RecipeIngredientID primary key Clustered,
RecipeID int not null
	Constraint FK_RecipeIngredientsRecipes_RecipeID  
	REFERENCES Recipes(RecipeID),
Description varchar(100) not null,
Quantity varchar(50) not null
)
go
-- Insert Recipes
BEGIN
SET IDENTITY_INSERT [dbo].[Recipes] ON 
INSERT [dbo].[Recipes] ([RecipeID], [Instructions], [PrepTime], [ItemID]) VALUES (1, N'Rinse the livers and pat dry with a kitchen towel. Clean the livers, by trimming and discarding any visible fat, green parts, or membrane. Set the livers aside. In a large saute pan, over medium heat, heat 1/2 cup of the chicken fat and add the onions. Cook, stirring occasionally, until golden brown, about 10 to 12 minutes. Transfer the onions to a container with a slotted spoon. Wipe out the pan. Working in batches of 1 pound, spread the livers out in a single layer on a sheet pan and season with the salt and pepper. Raise the heat to high, add 4 tablespoons of the fat to the pan and when the fat begins to shimmer, lay the livers in the pan in a single layer. Cook the livers turning each over once, until browned, about 2 to 2 1/2 minutes per side. Cool. Coarsely chop the livers with a knife (don''t be tempted to use a food processor). Gently combine the livers with the eggs, onions, and remaining fat. Season with salt and pepper to taste. Refrigerate.', 35, 13)
INSERT [dbo].[Recipes] ([RecipeID], [Instructions], [PrepTime], [ItemID]) VALUES (2, N'In a contain, mix together olive oil, the lime juice, soy sauce, cilantro, chile flakes and garlic. Sprinkle the scallops with salt and pepper. Add the scallops to the marinade, cover with plastic and refrigerate.', 30, 14)
INSERT [dbo].[Recipes] ([RecipeID], [Instructions], [PrepTime], [ItemID]) VALUES (3, N'Put the mushrooms in a small bowl and cover with boiling water and soak until re-hydrated, about 20 minutes. Drain, squeeze dry, and cut mushrooms in quarters. Set aside. Heat 1 tablespoon of the peanut oil in a well-seasoned wok or large non-stick skillet over medium-high heat. Swirl to coat the pan. Pour in the eggs, swirl the pan so the egg forms a large thin pancake. (Lift the edge of the egg to allow any uncooked egg to run to the center.) As soon as the egg has set, turn it out of the pan onto a cutting board. Cool, cut into 1 inch pieces. Wipe out the pan with a paper towel and heat the remaining peanut oil over high heat. Add the scallions and carrots and stir-fry for 1 1/2 minutes. Add the mushrooms, garlic, chile, and ginger, stir-fry for 1 minute more. Add the soy sauce, sesame oil and rice and stir-fry for 2 to 3 minutes. Add the meat, peas, and reserved egg, cook, stirring until heated through, about 2 to 3 minutes.', 50, 20)
INSERT [dbo].[Recipes] ([RecipeID], [Instructions], [PrepTime], [ItemID]) VALUES (4, N'Melt the stick of butter in a large pot over medium heat. Add the onions, garlic, bay leaves, thyme, and salt and pepper and cook until the onions are very soft and caramelized, about 25 minutes. Add the wine, bring to a boil, reduce the heat and simmer until the wine has evaporated and the onions are dry, about 5 minutes. Discard the bay leaves and thyme sprigs. Dust the onions with the flour and give them a stir. Turn the heat down to medium low so the flour doesn''t burn, and cook for 10 minutes to cook out the raw flour taste. Now add the beef broth, bring the soup back to a simmer, and cook for 10 minutes. Season, to taste, with salt and pepper.', 70, 29)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
END

-- Insert Recipe Ingredients
BEGIN
SET IDENTITY_INSERT [dbo].[RecipeIngredients] ON 
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (2, 1, N'chicken lievers', N'4 pounds')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (3, 1, N'Rendered chicken fat ', N'1 1/2 cuos')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (4, 1, N'coarsely chopped onion', N'4 cups')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (5, 1, N'kosher salt plus more', N'1/4 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (6, 1, N'Freshly ground pepper', N'to taste')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (7, 1, N'finely chopped hard-cooked large eggs', N'8')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (9, 2, N'olive oil', N'2 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (10, 2, N'lime juice', N'1 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (11, 2, N'low-sodium soy sauce', N'1 1/4 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (12, 2, N'chopped fresh cilantro', N'1 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (13, 2, N'crushed dried red chile flakes', N'1/4 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (14, 2, N'minced garlic', N'16 cloves')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (15, 2, N'jumbo sea scallops', N'6 pounds')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (16, 2, N'salt and ground black pepper', N'to taste')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (18, 3, N'dried shitake mushrooms', N'32')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (19, 3, N'peanut oil', N'3/4 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (20, 3, N'lightly beaten with a pinch of kosher salt', N'8')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (21, 3, N'scallions thinly sliced', N'16')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (22, 3, N'minced carrot', N'1 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (23, 3, N'minced garlic', N'4 cloves')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (24, 3, N'red chile flakes', N'pinch')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (25, 3, N'minced peeled ginger', N'1 tablespoon')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (26, 3, N'soy sauce', N'1/2 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (27, 3, N'toasted sesame oil', N'4 teaspoons')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (28, 3, N'cooked long-grain rice', N'12 cups')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (31, 3, N'cooked meat, pork,  beef,, or chicken', N'4 cups (1/2 inch cubes)')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (32, 4, N'unsalted butter', N'2 cups')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (33, 4, N'onions, sliced', N'16')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (34, 4, N'garlic, chopped', N'8 cloves')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (35, 4, N'bay leaves', N'8')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (36, 4, N'thyme sprigs', N'8')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (37, 4, N'Kosher salt', N'to taste')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (38, 4, N'ground black pepper', N'to taste')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (39, 4, N'red wine', N'4 cups')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (40, 4, N'all purpose flour', N'3/4 cup')
INSERT [dbo].[RecipeIngredients] ([RecipeIngredientID], [RecipeID], [Description], [Quantity]) VALUES (41, 4, N'beef broth', N'8 quarts')
SET IDENTITY_INSERT [dbo].[RecipeIngredients] OFF
END