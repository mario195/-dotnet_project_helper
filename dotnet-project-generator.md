Idee ist es, ein tool zu entwickeln, welches es dem User erlaubt, ein .Net core Projekt zu starten. 
Es sollte eine sln Datei, eventuell eine gitignore ud ein test projekt erstellt werden. Als Test Framework wird XUnit benutzt. Die nötigen Verweise erstellt das tool selbst. 

arameter sollen sein:
1. Anwendungsart (konsole, api, mvc...)-> string
2. git init ? -> bool
3. gitignore ? -> bool
4. test-projekt ? -> bool
5. Speicherort -> string

Das tool selbst ist als Konsoleanwendung geplant. es sollte ermittelt werden, ob es externe Bibliotheken gibt, welche es
erlauben, Systembefehle auszuführen.
Die Parameter werden dem Programm in Form von -parameter1 wert1 usw. übergeben.