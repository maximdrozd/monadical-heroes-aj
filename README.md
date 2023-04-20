# monadical-heroes-aj
Test task for Monadical inteview

Unity Take-Home Challenge (option 1):

Challenge:
-
You are developing a game called Heroes of AJ with the Monadical team. For the game, you must create a hero with a certain number of attributes (Health, Mana, Endurance, Intelligence). The hero can equip items from an inventory that alter the max value of their particular attributes. Design a system that allows for a hero to equip one or more items from an inventory, and have that item affect that hero's attributes. The hero must also be able to unequip an item, reverting their attributes to a previous state.

Bonus Points:

* Ensure that this system is generic to any type of attribute.
* Ensure that your hero system is capable of creating different heroes with different types of attributes.

Implemented:
- 
- Inventory system
- UI system
- Hero system

Store assets used:
- 
- Only graphical assets from *2D Battle Background*
- Only graphical assets from *Fantasy Free Icons Pack*
- Graphical assets and animations from *Mighty Heroes (Rogue) 2D Fantasy Characters Pack*
- Only graphical assets from *Simple Fantasy UI*

Usage:
-
- Launch the game
- Create a hero by pressing "+ Character" button
- Create some items "+ Item" button
- Pick up items by clicking on them
- Open inventory
- Click on hero to see hero pane (spawned heroes get 5 random stats from a list in HeroSystem)
- Equip / Remove items by clicking on them in Inventory or on Hero pane
- Stats change (heroes have base stats, equipment gained stats are shown on Hero pane after + sign. Ex: Strength: 5 + 16)
- New items can be created by changing scriptable object in Scripts/Data

Notes:
- 
- I didn't use existing repo by Monadical, as I was too excited to work on this and didn't see it until the second read of the email
- Some attributes in classes should be made private, I kept most things public for now as it speeds up development
