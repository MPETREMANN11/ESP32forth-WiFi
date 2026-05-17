\ *************************************
\ tests for IPv6
\    Filename:      tests.fs
\    Date:          22 apr 2026
\    Updated:       22 apr 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/tests.fs
cr ." tests loaded "

z" Livebox-1390L"      constant WIFI_SSID
z" z4S3RuPgdopjekrNQC" constant WIFI_PSWD

only forth 
also wifi

\ optionnel. Nettoie les anciennes connexions
WiFi.disconnect 

\ Connexion au WiFi (si pas déjà fait)
WIFI_SSID WIFI_PSWD WiFi.begin

\ Activer l'IPv6
WiFi.enableIPv6 .  \ Devrait répondre -1 (true)

\ Laisser le temps à l'ESP32 de négocier l'adresse avec le routeur
2500 ms

\ Afficher les adresses
." IPv4            : " WiFi.localIP . cr
." IPv6 Link-Local : " WiFi.linkLocalIPv6 type cr
." IPv6 Global     : " WiFi.globalIPv6    type cr


\ *** WiFi Scan ****************************************************************

only forth 
also wifi

WIFI_MODE_STA WiFi.mode

WiFi.disconnect              \ 2. On coupe toute tentative de connexion
500 ms                       \ 3. CRUCIAL : Laisser le driver souffler

WiFi.scanNetworks            \ 4. Lance le scan

0 WiFi.SSID z>s type
1 WiFi.SSID z>s type

0 WiFi.RSSI .
1 WiFi.RSSI .

0 WiFi.channel .
1 WiFi.channel .

0 WiFi.encryptionType .
1 WiFi.encryptionType .

WiFi.scanDelete        \ Libère les ressources


<EOF>

