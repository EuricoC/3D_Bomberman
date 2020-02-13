3D Multiplayer Bomberman game, built using unity and Photon2 for networking, includes main menu where you can create or joing an existing
room, room size is up to the MasterClient to decide waiting for players area, where you can move around and interact with other players,
MasterClient initialises the game when more than 2 players join, basic bomberman functionality, with powerups.

Known buggs to be fixed/missing features:

-Rooms stop being visible once a second player joins the room
-Players all spawn in the same location, instead of 4 different point
-Networking bug where bombs placed by other players influence local client bombPlaced variable, leading to too many bombs being allowed to be placed
-Missing bomb kicks
