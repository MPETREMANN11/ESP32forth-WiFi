\ *************************************
\ Manage wifi with IPv6
\    Filename:      wifiManage.fs
\    Date:          22 apr 2026
\    Updated:       21 may 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/wifiManage.fs

only forth 
also wifi

\ display IP in IPv4 format
: .ip ( ip -- )
    dup 255 and . ." ."
    dup 8 rshift 255 and . ." ."
    dup 16 rshift 255 and . ." ."
    14 rshift 255 and .
  ;

\ display status
: .status ( n -- )
    case
          0 of ." WL_IDLE_STATUS"       endof   \ temporary status
          1 of ." WL_NO_SSID_AVAIL"     endof   \ no SSId available
          2 of ." WL_SCAN_COMPLETED"    endof   \ networks analyse complete
          3 of ." WL_CONNECTED"         endof   \ connected
          4 of ." WL_CONNECT_FAILED"    endof   \ connection failed0
          5 of ." WL_CONNECTION_LOST"   endof   \ connection lost
          6 of ." WL_DISCONNECTED"      endof   \ disconnected
        255 of ." WL_NO_SHIELD"         endof   \ no wifi interface available
    endcase
    cr
  ;

\ display encryption, n is encryption number returned by
: decode-encryption  ( n -- addr len )
    case
        0 of s" Open " endof
        1 of s" WEP  " endof
        2 of s" WPA  " endof
        3 of s" WPA2 " endof
        4 of s" WPAx " endof
        5 of s" ENT  " endof
        6 of s" WPA3 " endof
        7 of s" WP3x " endof
        drop s" ???? " 
    endcase
  ;

\ wait for wifi connection
: wait-wifi ( -- )
    begin
        WiFi.status 3 <> \ 3 correspond à WL_CONNECTED
    while
        WiFi.status .status
        1000 ms
    repeat
        ." Connecté ! IP : " WiFi.localIP .ip cr 
  ;

: connect-wifi ( z-ssid z-pass -- )
    WIFI_MODE_STA WiFi.mode
    WIFI_SSID WIFI_PSWD WiFi.begin      \ connect to wifi router
    begin 
        WiFi.status 3 <> 
    while 
        100 ms 
    repeat \ Attente WiFi connecté
    
\     WiFi.enableIPv6 drop \ Active l'IPv6 (renvoie vrai/faux)
    ." IPv4: " WiFi.localIP . cr
    
    \ On attend que l'adresse IPv6 soit assignée par le routeur
\     begin 
\         WiFi.linkLocalIPv6 ( addr len ) 
\         dup 0= 
\     while 
\         2drop 500 ms 
\     repeat
\     ." IPv6: " type cr
  ;

<EOF>

