\ *************************************
\ wifi scan
\    Filename:      wifiScan.fs
\    Date:          27 apr 2026
\    Updated:       21 may 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************

RECORDFILE /spiffs/wifiScan.fs

only FORTH
also wifi

: .headNetwork  ( -- )
    ." chan | RSSI | encType  | SSID" cr
    ." -----+------+----------+---------------------------" cr    
  ;

: .vbar  ( -- )
    ."  | " ;

: .network  { netId -- }
    netId WiFi.channel 4 .r  .vbar
    netId WiFi.RSSI    4 .r  .vbar
    netId WiFi.encryptionType decode-encryption 8 -spaces .vbar
    netId WiFi.SSID z>s type cr
  ;

\ scan local wifi network
: net-scan  ( -- )
    WIFI_MODE_STA WiFi.mode
    WiFi.disconnect             \ cut all connexions
    500 ms                      \ wait for security
    cr ." Scan in progress..." cr
    WiFi.scanNetworks           \ Launch scan
    dup { ssidFounded }         \ store in local variable ssidFounded
    case
        -1 of ." Erreur: Scan failed (Busy)" cr exit    endof
        -2 of ." Error: WiFi not initialized" cr exit    endof
    endcase
    ." Founded networks: " ssidFounded . cr
    ssidFounded 0 > if
        .headNetwork
        ssidFounded 0 do
            i .network          \ display datas of each founded network
        loop
    then
    WiFi.scanDelete             \ free ressources
    ." Memory cleaned" cr 
  ;

only FORTH

<EOF>

