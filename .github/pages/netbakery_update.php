<?php

function exeparser_fileversion($file) {
    $parser_model = array('begin'=>"F\x00i\x00l\x00e\x00V\x00e\x00r\x00s\x00i\x00o\x00n",'end'=>"\x00\x00\x00");
    if (file_exists($file) && is_readable($file)) {
        $version = file_get_contents($file);
        $version = explode($parser_model['begin'], $version);
        $version = explode($parser_model['end'], $version[1]);
        $version = str_replace("\x00", null, $version[1]);
        return trim($version, ' ');
    } else {
        return false;
    }
}

$currentDir = dirname(__FILE__);
$file = $currentDir.'/netbakerysetup.latest.exe';

$version = exeparser_fileversion($file);

header("Content-Type:text/xml");
echo '<?xml version="1.0" encoding="utf-8" ?>';
echo '<item>';
echo '<version>'.$version.'</version>';
echo '<url>https://netbakery.cmbsolutions.nl/v2/netbakerysetup.latest.exe</url>';
echo '<mandatory mode="1">true</mandatory>';
echo '</item>';
