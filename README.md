# Morphing

Unity Version - 2022.3.28f1
Projektszene unter /Assets/OutdoorsScene.unity
HDRP Projekt und viel Nutzung vom Visual Effects Graph führt zu intensiver Nutzung der GPU, weshalb ich empfehle eine starke GPU zu haben.

---
### Character
Modell aus dem Internet
Animation aus dem Internet aber Übergänge und Geschwindigkeit angepasst.

**Character Controls** durch "neues" Unity Input System
WASD - Move (Theoretisch auch mit Controller)
AD / Mouse - Camera (Theoretisch auch mit Controller)
E - Interagieren in der Nähe von pink-leuchtenden Objekten.

**Interaktionen und Skripte**
Interaktionen, Inputs(also Character Controller etc.) und weitere Skripte sind home made by me (Komplett von mir gemacht).
Alle Objekte mit denen man interagieren kann, haben einen Collider. Im Gebiet des Colliders erscheint die UI und sagt man kann interagieren.

**Kamera**
Hierbei habe ich mir ein Tutorial zu Cinemachine angesehen und die Kamera eigenständig erstellt und angepasst. Die Third-Person Sicht ist damit smoother.

---
### Szene
Darstellung vom "Weltraum" wird durch ein in HDRP eingebauten Volume/Physical Based Sky erschaffen. (Textur wurde den veröffentlichen Bildern der NASA entnommen.)
##### Spaceship
Prefabs und Models der Wände, Böden und Dekorationen sind folgendem Asset aus dem Asset Store entnommen: https://assetstore.unity.com/packages/3d/environments/sci-fi/sci-fi-styled-modular-pack-82913
Das gesamt Konstrukt wurde aus den Assets von mir zusammengefügt und einiges davon mit Leben gefüllt.
Es gibt 8 "Räume" in jedem sind verschiedene Visual Effects zu finden.

*Alle Effekte die nicht konkret als CopyPaste oder ähnliches gekennzeichnet sind, habe ich selber gemacht*

**Startraum**
Links vom Start aus dem Fenster findet man einen "Wettereffekt", einen großen aus Partikeln bestehenden Meteoriten und kleinere fliegende Partikel.

**Warp Raum**
Interaktion mit Computern führt zur Aktivierung/Deaktivierung vom Warpeffekt. Erstellt mit Shadergraph und Visual Effect Graph. Inspiration(Textur und Effekt ist anders) von folgendem Video: https://www.youtube.com/watch?v=VsGG5JYlqIU

**Raccoon Room**
Zwischen Startraum und diesem sieht man bereits einige Sparks aus kaputten Bildschirmen kommen. Einige große Batterien aus denen Sparks kommen und eine Heat Distortion aus Effekten hat. Die Sparks sind inspiriert aus folgendem Video (welches das Particle System verwendet hatte):
https://www.youtube.com/watch?v=HV3g--GyEW0&pp=ygUQc3BhcmtzIHVuaXR5IHZmeA%3D%3D

Heat Distortion ist copy paste aus folgendem Tutorial: https://www.youtube.com/watch?v=CXCyVDEplyM

Außerdem läuft ein Waschbär (Modell und Animation aus dem Internet) von 4 Spawn Points geradeaus durch bis er verschwindet, hierbei habe ich copy paste des Shader Graphs und VFX Graph von folgendem Video aber mit einigen Anpassungen: https://www.youtube.com/watch?v=vMd5GnP5c8o&list=PLpPd_BKEUoYhN8CiOoNLTSVh-7U5yjg3n&index=52&pp=iAQB

**HoloHolo Raum**
Rechts ist eine Holomap, diese ist copy paste aber mit eigener Kamera Platzierung und Änderung kleiner Werte von diesem Tutorial: https://www.youtube.com/watch?v=1BVRN_TP4m8

Auch rechts aber weiter vorne ist ein wechselbarer "Flammen-"/"Heilungs-" Werfer, dieser ist copy paste aus folgendem Tutorial aber mit einigen Änderungen: https://www.youtube.com/watch?v=IY2K2cOE0R8

Links befindet sich der erste "Morph" oder eher Formänderungseffekt, die Modelle habe ich aus dem Internet herausgesucht, aber alle zu SDF selbst abgewandelt.
Man kann durch Interaktion das dargestellte Modell ändern.
Für das VFX Graph ist 60% aus dem folgenden Video und 40% von mir: https://www.youtube.com/watch?v=FBP9k6W48vM

**Vor draußen Raum**
Zwei Bälle der rechts ist inspiriert aus verschiedenen Videos zusammen, ich kriege diese auch nicht mehr zusammengesammelt.
Der verfluchte Ball links ist komplett von mir und wenn man sich dem Ball zu nah kommt triggert der Collider und der zweite Teil des Effektes wird getriggert, indem die Position neu gesetzt wird.

**Draußen Raum**
Hier ist der Effekt rechts ein Morph Effekt, Modelle wieder aus dem Internet. Mathe ist aus dem Internet allerdings habe ich ein paar Sachen angepasst und den Shader ausgelassen: https://realtimevfx.com/t/unity-vfx-graph-alien-morph/10829

Der Effekt links ist ein besonders anstrengend zu verstehender auch Morph Effekt gewesen. Hier kann man das Model mit Interaktion ebenfalls ändern. Auch kann man den Effekt Neustarten da er mit Single Burst erstellt wird.
Außer optischer Änderungen und mehr Möglichkeiten zur Anpassung des Effektes ist der Rest von folgendem Video kopiert: https://www.youtube.com/watch?v=ZytOQ4NSciU

Den letzten Effekt, eine tanzende humanoide aus Effekt bestehende Sache, habe ich selber hinbekommen aber habe danach zur Sicherheit ein Video nochmal dazu angesehen um mein Vorgehen zu bestätigen. Das Modell sowie die Animation habe ich von Mixamo.

**Sonstiges Raum**
50% der Effekte in diesem Raum sind copy paste aus Tutorials, Dokumentationen und Unity Learning aber manche mit einigen eigenen Anpassungen.

~~**Pipe Room**~~
~~Nicht umgesetzt~~

---
### Highlights und Lowlights

**Shadergraph**
Definitv ein Lowlight.
Ich habe sehr lange an verschiedenen Shadergraphs arbeiten wollen und hatte als Ziel den Time Node zu nutzen. Bestimmt habe ich erst nach Tagen herausbekommen wie ich "Always Refresh" aktiviere. Ich war sogar kurz davor auf URP zu wechseln da es auf solchen Projekten direkt funktioniert hatte aber ich habe mich zusammengereist und mein Bestes versucht. Am Ende war ich müde vom Shadergraph und habe daher nicht mehr viel damit machen wollen.

**Trigger/Interaktionssystem**
Ein Interaktionssystem habe ich sehr schnell hinbekommen sobald ich die Idee aufgeblitzt im Kopf hatte. Ich hätte es gerne deutlich optimiert leider habe ich es nicht. Es funktioniert ist super cool und hoffentlich nichts verbotenes im Coding. Im Scripts/Interactions Ordner findet ihr die Beispiele.

**Perfektionismus und allgemein Zahlendrehen**
Ein Lowlight war das exzessive Zahlendrehen. Zwar habe ich viele Effekte dem Internet entnommen aber ich wollte das es ein bisschen anders aussieht bzw. ein bisschen mehr so wie ich wollte. Deshalb habe ich viele Zahlen gedreht und das hat mich oft Stunden gekostet. Kann ich niemandem empfehlen. Einmal Zahlendrehen okay aber nicht stundenlang.

**HDRP Starmap Lighting**
Super schnell aufgesetzt und es sieht super schön aus. Wenn ich jemals HDRP wieder verwende schaue ich mir das Lighting und die Volume einstellungen nochmal an, weil dort viel gemacht werden kann.

**Spaceship**
Beides trifft zu. Es war super gut das ich mich für ein Spaceship entschieden habe und gute freie Assets finden konnte. Leider konnte ich mich nicht für ein spezielles Design entscheiden, weswegen ich mehrere Assets probiert hatte zu einem Schiff zu verbinden. Es war anstrengend und hat etwas lange gebraucht, ich habe vieles unnötiges gemacht und wieder gestrichen. Aber im Endeffekt war es eine gute Idee wenn auch anstrengend.

---
### Honorary Mentions
https://www.youtube.com/@EricWang0110
https://www.youtube.com/@GabrielAguiarProd

Diese zwei haben besonders gute Tutorials gehabt.

Morgan habe ich auch angeguckt und versucht zu verstehen leider viel zu viel Mathe und so unglaublich komplex.
