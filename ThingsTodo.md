### BGraphic.DrawUI()
- Needs to draw to the screen without camera offset
- BMenuState should use this method to draw a texture instead of a white rectangle

### BCharacter Collision
- All classes derived from BCharacter should have this

### BEntities
- Initialise all entities

### BGameSave
- Save entities
- Load entities
- Add json constructures to BEntity, BCharacter and BPlayableCharacter
