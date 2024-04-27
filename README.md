# TypeKitExporter
TypeKit Exporter is a simple command line tool to export your installed TypeKit fonts to TTF files.
## Commands
### List
List all installed TypeKit fonts.
```shell
TypeKitExporter.exe list
```
### Export
#### Single
Export a single font by its name.
```shell
TypeKitExporter.exe export single "Myriad Pro"
```
##### Options
- `-o` or `--output` (optional): The output directory. Default is the current directory.
#### Family
Export all fonts of a family by its name.
```shell
TypeKitExporter.exe export family "Myriad Pro"
```
##### Options
- `-o` or `--output` (optional): The output directory. By default, the fonts are exported to a subdirectory named after the family.
## Disclaimer
This tool is for educational purposes only. Please respect the license agreements of the fonts you are exporting.