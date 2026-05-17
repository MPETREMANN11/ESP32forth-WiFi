\ *************************************
\ wifi scan
\    Filename:      wifiScan.fs
\    Date:          27 apr 2026
\    Updated:       28 apr 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************

RECORDFILE /spiffs/wifiScan.fs

\ display encryption, n is encryption number returned by
: .encryption ( n -- )
    case
        0 of ." Open " endof
        1 of ." WEP  " endof
        2 of ." WPA  " endof
        3 of ." WPA2 " endof
        4 of ." WPAx " endof
        5 of ." ENT  " endof
        6 of ." WPA3 " endof
        7 of ." WP3x " endof
        drop ." ???? " 
    endcase
  ;

only FORTH
also wifi


: .headNetwork ( -- )
    ." chan  RSSI  encType  SSID" cr
    ." ----------------------------------------------------" cr    
  ;

: .network  { netId -- }
    netId WiFi.channel 4 .r   3 spaces
    netId WiFi.RSSI    3 .r   2 spaces
    netId WiFi.encryptionType space .encryption 3 spaces
    netId WiFi.SSID z>s type cr
  ;

: scan-pro ( -- )
    WIFI_MODE_STA WiFi.mode

    WiFi.disconnect              \ 2. cut all connexions
    500 ms                       \ 3. wait for security

    cr ." Scan in progress..." cr
    WiFi.scanNetworks            \ 4. Launch scan
    { ssidFounded }
    ssidFounded
    case
        -1 of ." Erreur: Scan echoue (Busy)" cr exit    endof
        -2 of ." Erreur: WiFi non initialise" cr exit   endof
    endcase
    ." Founded networks: " ssidFounded . cr

    ssidFounded 0 > if
        .headNetwork
        ssidFounded 0 do
            i .network
        loop
    then

    WiFi.scanDelete        \ free ressources
    ." Memory cleaned" cr ;

only FORTH

<EOF>

