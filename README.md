# alimentation-BDD-a-partir-de-fichier-CSV
interface d'alimentaion de la bdd avec un fichier csv contenant les informations des éleves

Objectifs :

-> Mettre en place une application windows Form qui ajoutera les élèves dans la base de données grâce à leurs informations présentes dans      un fichier de type CSV

Contraintes :

-> Les élèves doivent être ajoutés dans un premier temps dans la table utilsateurs avant d'être ajoutés dans la table élèves, il faut donc leur constituer un mot de passe et le hashé en MD5/SHA256 avant insertion dans la table pour qu'il puissent se connecter par la suite sur le site

-> dans la BDD un élève est affilié à une classe qui est elle même affiliée à un enseignant, il est donc nécessaire de charger dans l'interface graphique les enseignants et leurs classes afin d'en selectionner une pour l'insertion des élèves.

-> mettre en place un checkbox dans l'interface graphique qui permet de définir si on souhaite supprimer les élèves déja présents dans la classe selectionnée avant l'insertion des élèves du fichier CSV
