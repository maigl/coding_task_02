# Aufgabe:

Implementieren Sie eine Funktion MERGE die eine Liste von Intervallen entgegennimmt und als Ergebnis wiederum eine Liste von Intervallen zurückgibt.
Im Ergebnis sollen alle sich überlappenden Intervalle gemerged sein. Alle nicht überlappenden Intervalle bleiben unberührt.

Beispiel:  
Input: [25,30] [2,19] [14, 23] [4,8]  Output: [2,23] [25,30]

Wie ist die Laufzeit Ihres Programms ?   
Wie kann die Robustheit sichergestellt werden, vor allem auch mit Hinblick auf sehr große
Eingaben ?  
Wie verhält sich der Speicherverbrauch ihres Programms ?

# Zeit

~150min

# Umgebung
Windows 10  
Visual Studio 2022 Community Edition

# Fragen

## Wie ist die Laufzeit Ihres Programms?

Die Laufzeit für das oben genannte Beispiel sind `2,391` Sekunden.  
Leistungbericht: `Bericht20220318-0900.diagsession`

## Wie kann die Robustheit sichergestellt werden, vor allem auch mit Hinblick auf sehr große Eingaben?

Hierzu fallen mir folgende Möglichkeiten ein:

1. Prüfung ob, das Intervall valide ist. 

```Csharp
public UInt16 B
        {
            get { return b; }
            set
            {
                if (value > this.A)
                {
                    b = value;
                }
                else throw new ArgumentOutOfRangeException("B", "The end of the interval must be greater than the beginning");
            }
        }
```
2. Die Auswahl der Variablentypen sollte entsprechend dem Anwendungsszenario ausgewählt werden. Bei der Aufgabe verwende ich `unsigned 16Bit integer`, bedeutet die Zahlen sind `ganzzahlig` und `positiv`.  Damit können also Intervalle von `0 bis 65.535` dargestellt werden.

## Wie verhält sich der Speicherverbrauch ihres Programms ?

```
4      Inputs :    47,544 KB ~ 11,88 KB
100    Inputs :    48,752 KB ~ 0,480 KB
1000   Inputs :    55,920 KB ~ 0,055 KB
10000  Inputs :   181,624 KB ~ 0,018 KB
100000 Inputs : 1.099,304 KB ~ 0,010 KB
```

Der Speicherverbrauch erhöht sich pro Input um ~0,01 KB, man erkennt gut, das für die gesamte Laufzeit erstmal initial ~47 KB benötigt werden.

Der Speicherverbrauch verhält sich also steigend mit größerer Input Anzahl.

# Build

Hierzu wird das Microsoft Tool `MSBuild` benötigt, das direkt vom Hersteller bezogen werden kann: https://visualstudio.microsoft.com/de/downloads/

Tools für Visual Studio 2022 -> Buildtools für Visual Studio 2022

Bei der Installation müssen die Komponenten `NET SDK` sowie `NET Runtime 5.0` ausgewählt werden.

```powershell
MSBuild.exe ./coding_task_02/coding_task_02.csproj -property:Configuration=Release
# Anwendung starten
.coding_task_02/coding_task_02/bin/Release/net5.0/coding_task_02.exe
```