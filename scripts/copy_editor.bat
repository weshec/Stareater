rem Copies ZvjEdit.exe from {projDir}/bin/debug/
rem or {projDir}/bin/release/ to {svnRoot}/editors/
rem
rem Used as post build action i Zvjezdojedac editori
rem project.

@echo off
copy ZvjEdit.exe ..\..\..\..\editors\
