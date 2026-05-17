\ *************************************
\ main for IPv6
\    Filename:      main.fs
\    Date:          22 apr 2026
\    Updated:       22 apr 2026
\    File Version:  1.0
\    MCU:           ESP32
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/main.fs

internals 120 to line-width forth

: .R  ( n1 n2 -- )
    SWAP DUP >R ABS <# #S R> SIGN #> ( n2 c-addr u )
    ROT OVER - SPACES TYPE
  ;

DEFINED? --ipv6 [if] forget --ipv6  [then]
create --ipv6

include /spiffs/config.fs
include /spiffs/wifiManage.fs
include /spiffs/wifiScan.fs
\ include /spiffs/assert.fs
\ include /spiffs/tests.fs

<EOF>






