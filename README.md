# SI4 : Service oriented computing - Web Services

Ce service permet d'obtenir la liste des villes de l'API de JCDecaux ainsi que leurs différentes stations et les détails de ces stations.
Il peut être utilisé sous deux formes:
- Une application console
- Un GUI

##Extensions Choisies

- Graphical User Interface for the client
- Add a cache in IWS, to reduce communications between Velib WS and IWS
- Replace all the accesses to WS (between IWS and GUI Client) with asynchronous ones. Some indications can be find just below.

##Architecture du projet
- VelibService:  Le web service SOAP faisant l'intermédiaire entre les clients et l'api de JCDecaux
- ClientSOAP: Client console communiquant avec le service SOAP
- GUI: Client utilisateur graphique communiquant avec le service SOAP
- CacheWS: Client Administrateur graphique communiquant avec le service SOAP pour changer la durée du cache

##Lancement du projet
Lancer le projet VelibService
Démarrer au choix le projet ClientSOAP, GUI ou CacheWs pour accéder à l'interface souhaitée

##Utilisation des différents clients
### ClientSOAP
Ecrire "help" dans la console pour accéder à l'aide. Puis suivre les instructions s'affichant à l'écran:
- Afficher ou non les villes proposées
- Choisir la ville
- Afficher ou non les stations proposées
- Choisir la station
- Lire les informations sur l'écran

### GUI
- Choisir dans la liste du haut la ville souhaitée
- Choisir la station dans la liste du milieu
- Le détails de la station s'affichent dans la partie du bas
- N.B: Pour rafraichir les informations appuyer sur "Refresh"

### CacheWS
Ecrire la valeur voulue (en minutes) puis appuyer sur "Sauvegarder"
Les valeurs par défaut sont:
- CITY_TIME = 43 200 min;
- STATION_TIME = 2 min;
- DETAILS_TIME = 2 min;

