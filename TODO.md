TODO

Make GameOver UI look better/more appealing
In the GameOver script, code both Retry() and Menu() functions so that clicking Retry "restarts" the game and clicking Menu takes us back to the MainMenuScene.              
Utilize SceneFader script/object to do this, function that helps is SceneFader.Fade() I believe?


In the MainMenu scene, create scripts/functionality so that clicking Play changes our scene to BattleScene and clicking Quit acts as a "Quit" button


Add Score GUI to BattleScene, maybe display it during the GameOver screen as well.                                       
Maybe put Score variable in PlayerInfo script or GameManager script? Not sure which is better


Implement it so that player loses health when enemy comes into contact for certain period of time.

"Freeze" game when GameOver UI appears and continue it after either Menu or Retry is clicked.


THINGS TO NOTE

GameOver UI is in the Hierarchy under OverlayUI. Tick the box in the inspector to view it

When playing the game, press "G" to make player lose lives. Screen should pop up when lives reaches 0, (I set health to 1 under Player object, you should just need to press it once).

Buttons in the GameOver screen are already clickable, but right now they only output a debug statement in the console.
