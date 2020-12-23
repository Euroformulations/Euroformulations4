SET src_folder=%cd%\app
SET tar_folder=%cd%
for /f %%a IN ('dir "%src_folder%" /b') do move "%src_folder%\%%a" "%tar_folder%"
RD /S /Q "%cd%\app"
RD /S /Q "%cd%\cluster"
unzip auto_cluster.zip
cd include
DEL config.ef4
cd..
MOVE auto_config.ef4 include\
RENAME "%cd%\include\auto_config.ef4" config.ef4