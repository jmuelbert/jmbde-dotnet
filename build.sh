#!/usr/bin/env bash
repoFolder="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
cd $repoFolder

jmbdeBuildZip="https://github.com/jmuelbert/jmbde-aspnet/archive/master.zip"
if [ ! -z $JMBDEBUILD_ZIP ]; then
    jmbdeBuildZip=$JMBDEBUILD_ZIP
fi

buildFolder=".build"
buildFile="$buildFolder/JMBDEBuild.sh"

if test ! -d $buildFolder; then
    echo "Downloading JMBDEBuild from $jmbdeBuildZip"
    
    tempFolder="/tmp/JMBDEBuild-$(uuidgen)"    
    mkdir $tempFolder
    
    localZipFile="$tempFolder/jmbdebuild.zip"
    
    wget -O $localZipFile $jmbdeBuildZip 2>/dev/null || curl -o $localZipFile --location $jmbdeBuildZip /dev/null
    unzip -q -d $tempFolder $localZipFile
  
    mkdir $buildFolder
    cp -r $tempFolder/**/build/** $buildFolder
    
    chmod +x $buildFile
    
    # Cleanup
    if test ! -d $tempFolder; then
        rm -rf $tempFolder  
    fi
fi

$buildFile -r $repoFolder "$@"