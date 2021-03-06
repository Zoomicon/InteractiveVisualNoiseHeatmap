## InteractiveVisualNoiseHeatmap

Demo application for *Readable Athens* art project

See https://www.researchgate.net/publication/282660465_Readable_City_Soundscapes_reading_visual_noise_in_the_hybrid_city

Pins JPGs from a folder on a map (using GPS EXIF info), shows at pin hover, plays louder noise closer to more text (*.jpg.txt OCRed)

Software:

This is a desktop (WPF) application for Windows, that loads JPG images from a folder and displays pins on a map (OpenStreetMap), based on the EXIF GPS data in the images. 

* When the mouse moves over the map, it plays crowd-noise sound based on how much text is contained in the images of the nearby pins and how far the mouse cursor is from them. The software doesn't do OCR, but expects to find the images' text in .txt files named the same as the image filenames, placed at a separate subfolder.

* When the mouse moves over a pin it displays its image. 
