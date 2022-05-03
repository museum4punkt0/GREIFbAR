# GREIFbAR App – Augmented Reality im Museum anschaulich erklärt
## Inhaltsverzeichnis 
* [Kurzbeschreibung](#Kurzbeschreibung) 
* [Förderhinweis](#Förderhinweis) 
* [Dokumentation](#Dokumentation) 
* [Installation](#Installation) 
* [Credits](#Credits) 
* [Lizenz](#Lizenz)
# Kurzbeschreibung
Augmented Reality (AR) ist ein mächtiges aber auch komplexes Medium. Oft laufen Vorstellungen und Machbarkeit auseinander - Potentiale bleiben ungenutzt. Genau hier setzt die App „GREIFbAR“ an und macht Chancen sowie Herausforderungen dieses Vermittlungswerkzeugs für Kulturinstitutionen und Museen erfahrbar – auch ohne AR-Vorkenntnisse. Durch das gewonnene Verständnis sollen insbesondere im Kultursektor tätige Personen bei der erfolgreichen Umsetzung von AR-Projekten und der effektiven Kommunikation mit Projektpartnern unterstützt werden.\
Die folgenden acht Module sind gegenwärtig verfügbar und beantworten einige der wichtigsten Fragen rund um Augmented Reality:
-	Was ist Augmented Reality?
-	Wozu Augmented Reality?
-	AR-Inhalt
-	Tracking
-	Aufwand
-	Einsatzmedien
-	Mit eigenen Inhalten AR selbst erstellen
-	Beispielprojekte
# Förderhinweis
Diese native App ist entstanden im  Verbundprojekt  museum4punkt0  –  Digitale  Strategien  für  das  Museum  der  Zukunft, M3 - Deutsches Museum. Das Projekt museum4punkt0 wird gefördert durch die Beauftragte der Bundesregierung für Kultur und Medien aufgrund eines Beschlusses des Deutschen Bundestages. Weitere Informationen:\
www.museum4punkt0.de

![alt text](https://github.com/museum4punkt0/media_storage/blob/2c46af6cb625a2560f39b01ecb8c4c360733811c/BKM_Fz_2017_Web_de.gif) ![alt text](https://github.com/museum4punkt0/media_storage/blob/e87f37973c3d91e2762d74d51bed81de5026e06e/BKM_Neustart_Kultur_Wortmarke_pos_RGB_RZ_web.jpg)
   
# Dokumentation
GREIFbAR wurde in der Entwicklungsumgebung Unity umgesetzt. Unity bietet 
**Aufbau der App und des Projekts**\
Die App ist aus einem Start-Modul und acht weiteren Inhaltsmodulen aufgebaut (Alle Module haben eine Kennziffer): Start(00), WhatsAR(01), Tracking(02), Tryit(03), ARContent(04), Effort(05), WhyAR(06), Media(07), Examples (08). 
Das Start-Modul besteht aus einer Intro-Szene mit einer kleinen AR-Sequenz und einer Home-Szene, die das Menü der App darstellt. (Skripte und Struktur unterscheiden sich von den anderen Modulen)\
Alle anderen Module bestehen aus kleineren Menüpunkten, aus Erklärseiten und meist aus AR-Sequenzen. Diese Module sind strukturell fast gleich aufgebaut. 
Im Asset-Ordner befinden sich alle Dateien der App, die für die Entwicklung wichtig sind. Dabei sind folgende Ordner besonders relevant:
Animations, ARstuff (jegliche Augmented Reality Inhalte), Images, Scenes und Scripts 
(Alle Inhalte und Ordner eines Moduls sind mit der Kennziffer des Moduls gekennzeichnet.)

**Navigation**\
Das Skript „BTTN_Navigation“ ist für die Navigation in der App zuständig (außer im Home-Menü). Das Skript ermöglicht eine lineare Navigation, man kann Erklärbilder und Texte auszutauschen, Objekte ein- und ausblenden und zu einer neuen Szene wechseln. 
Die restliche Navigation liegt auf den einzelnen Buttons.

**Augmented Reality**\
Die App ermöglicht in mehreren Modulen den Einsatz von Augmented Reality und nutzt dabei das Framework „ARFoundation“. 
Das Plug-In ermöglicht sowohl AR-Oberflächenerkennung wie auch Bildererkennung.

**Weitere Plug-Ins**\
Neben den AR-Plug-Ins und Frameworks wurden weitere kostenpflichtige Plug-Ins eingebunden:
 
Zudem liegt hier eine Liste aller notwendigen Frameworks vor:
 

# Installation
Zur Benutzung der App werden Smartphones oder Tablets benötigt, die ein Android Betriebssystem verfügen. Die Anwendung läuft ab folgenden Betriebssystemen: Android Pie 9.0. Die App kann im Playstore heruntergeladen und installiert werden. https://play.google.com/store/apps/details?id=com.DeutschesMuseum.GREIFbAR&gl=DE

Das Repository beinhaltet alle Assets der App ohne externe Plug-Ins und Frameworks. Es kann mit der aktuellen Unity 2020.3 LTS Version geöffnet werden. Beim Öffnen sollten alle kostenfreien Frameworks und Libraries nachgeladen werden. Ist das nicht der Fall, sollte der „Package Manager“ mit der obigen Liste abglichen werden. Dabei zeigt die Versionsnummer auf der linken Seite die minimale Version des jeweiligen Frameworks an. Zudem sind für folgende Module kostenpflichtige Plug-Ins notwendig, die im Assetstore von Unity heruntergeladen werden können:

02_Tracking/02_ARGPS benötigt [AR+GPS Location](https://assetstore.unity.com/packages/tools/integration/ar-gps-location-134882#description)\
03_Tryit/03_Tryit benötigt [TriLib 2](https://assetstore.unity.com/packages/tools/modeling/trilib-2-model-loading-package-157548#description) und [Native Gallery for Android & iOs](https://assetstore.unity.com/packages/tools/integration/native-gallery-for-android-ios-112630#description)\
06_WhyAR /06ARwhy benötigt [Paintz Free](https://assetstore.unity.com/packages/tools/paintz-free-145977#description)

Alle Grundfunktionen können ohne die PlugIns genutzt werden. 
Werden diese Szenen aus der App entfernt, funktionert die App auch ohne zusätzliche PlugIns. 

# Credits
Auftraggeber: Deutsches Museum, museum4punkt0
Konzept: Gabriel von Münchow, Alexander Schmidt
Gestaltung & Entwicklung: Gabriel von Münchow
# Lizenz
Copyright © 2022, Deutsches Museum
Hiermit wird jeder Person, die eine Kopie dieser Software und der zugehörigen Dokumentationsdateien (die "Software") erhält, kostenlos die Erlaubnis erteilt, uneingeschränkt mit der Software zu handeln, einschließlich und ohne Einschränkung der Rechte zur Nutzung, zum Kopieren, Modifizieren, Zusammenführen, Veröffentlichen, Verteilen, Unterlizenzieren und/oder Verkaufen von Kopien der Software, und Personen, denen die Software zur Verfügung gestellt wird, dies unter den Bedingungen der MIT-Lizenz zu gestatten.

