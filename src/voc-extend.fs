\ *************************************
\ Extend FORTh vocabulary
\    Filename:      voc-extend.fs
\    Date:          21 may 2026
\    Updated:       21 may 2026
\    File Version:  1.0
\    MCU:           ESP32 general
\    Forth:         ESP32forth all versions 7.x++
\    Copyright:     Marc PETREMANN
\    Author:        Marc PETREMANN
\    GNU General Public License
\ **************************************


RECORDFILE /spiffs/voc-extend.fs

\ add spaces to a string in a field of n characters, left aligned
: -spaces { c-addr c-len field-len -- }
    c-addr c-len type
    field-len c-len - spaces
  ;

\ display a number n1 in a field of n2 chacacters, right aligned
: .r ( n1 n2 -- )
    SWAP DUP >R ABS <# #S R> SIGN #> ( c-addr u n2 )
    ROT OVER - SPACES TYPE
;

<EOF>
