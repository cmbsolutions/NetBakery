<?php
//ini_set('display_errors', 1);
//ini_set('display_startup_errors', 1);
//error_reporting(E_ALL);

function exeparser_fileversion(string $file, string &$checksum): bool|string
{
    $parser_model = [
        'begin' => "F\x00i\x00l\x00e\x00V\x00e\x00r\x00s\x00i\x00o\x00n",
        'end' => "\x00\x00\x00"
    ];

    if ( file_exists($file) && is_readable($file) ) {
        $version = file_get_contents($file);
        $checksum = hash('SHA384', $version);
        $version = explode($parser_model['begin'], $version);
        $version = explode($parser_model['end'], $version[1]);

        return trim(str_replace("\x00", '', $version[1]), ' ');
    } else {
        return false;
    }
}

$currentDir = dirname(__FILE__);
$zipfile = $currentDir.'/netbakerysetup.latest.zip';
$file = $currentDir.'/netbakerysetup.latest.exe';

if ( file_exists($zipfile) ) {
    if ( file_exists($file) ) unlink($file);

    $zip = new ZipArchive();
    if ( $zip->open($zipfile) === true ) {
        $zip->extractTo($currentDir);
        $zip->close();
    }

    if ( file_exists($file) ) unlink($zipfile);
}

$checksum = '';
$version = exeparser_fileversion($file, $checksum);

header("Content-Type:text/xml");
echo '<?xml version="1.0" encoding="utf-8" ?>';
echo '<item>';
echo '<version>'.$version.'</version>';
echo '<url>https://www.cmbsolutions.nl/netbakery/netbakerysetup.latest.exe</url>';
echo '<mandatory mode="1">true</mandatory>';
echo '<checksum algorithm="SHA384">'.$checksum.'</checksum>';
echo '</item>';
