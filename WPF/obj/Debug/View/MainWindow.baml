   M S B A M L   `   `   `  ����V  RMapControl.WPF, Version=1.11.3.0, Culture=neutral, PublicKeyToken=f26fcf0059638459?0clr-namespace:MapControl;assembly=MapControl.WPF
MapControl  5      I EReadableAthens, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ReadableAthensReadableAthens 5      #   ReadableAthens.WPF.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @map0clr-namespace:MapControl;assembly=MapControl.WPF     5      .localclr-namespace:ReadableAthens     5        � Title$  Readable Athens��5	      $	��800��5
      $	��600��6    � WindowState$ 	Maximized=�5       �� IsPressAndHoldEnabled .   � 	Resources 5      2  ,ReadableAthens.LocationToVisibilityConverter !  LocationToVisibilityConverter$   MapControl.TileLayerCollection  
TileLayers   MapControl.TileLayer   
SourceName   Description   
TileSource$   MapControl.TileSourceConverter  TileLayersViewSource �� Source  PushpinItemStyle �� 
TargetType   MapControl.MapItem	 �� Property
 �� Value   MapControl.MapPanel `� 	Converter �� Path �� RelativeSource �� 
TargetType   MapControl.Pushpin �� AncestorType ^� ToolTip �� Triggers P� Property P� Value��%  &	        &	      &	     7  &	      7     5      6*     5        5      $ OpenStreetMap��5   	   $1 +© {y} OpenStreetMap Contributors, CC-BY-SA��5   	   $7 1http://{c}.tile.openstreetmap.org/{z}/{x}/{y}.png 5   	     5      $ OpenCycleMap��5   	   $M GOpenCycleMap - © {y} Andy Allen & OpenStreetMap Contributors, CC-BY-SA��5   	   $< 6http://{c}.tile.opencyclemap.org/cycle/{z}/{x}/{y}.png 5   	     5      $ OCM Transport��5    	   $W QOpenCycleMap Transport - © {y} Andy Allen & OpenStreetMap Contributors, CC-BY-SA��5!   	   $A ;http://{c}.tile2.opencyclemap.org/transport/{z}/{x}/{y}.png 5"   	     5$      $ OCM Landscape��5%   	   $W QOpenCycleMap Landscape - © {y} Andy Allen & OpenStreetMap Contributors, CC-BY-SA��5&   	   $A ;http://{c}.tile3.opencyclemap.org/landscape/{z}/{x}/{y}.png 5'   	     5)      $ MapQuest OSM��5*   	   $A ;MapQuest OSM - © {y} MapQuest & OpenStreetMap Contributors��5+   	   $? 9http://otile{n}.mqcdn.com/tiles/1.0.0/osm/{z}/{x}/{y}.png 5,   	   5.      �� 50      8   52      �� 55      "  6%   .�56      �� 	 � ��

 �   �6%   �� 57      	 � ��
 �	#80FF00006%   �� 58      	 �@ Location
 60   �� *
Location+�� 59      	 � y�
 5:   
   `� 5;      8   .1�5<      �� $ (map:MapPanel.ParentMap)�6    66   �� *Self+�� 5=      $ RenderTransform�6    6-   �� *Self+5>      5@   	   �� 5A      	 � ��$

 Left=�6.   �� 5B      	 � ��$
 Bottom=�6,   �� 5C      	 � ��
 5D   
   �� 5E      "  6   .R�5F        ��5G      �� *Name+��5H      �� *
Foreground+ �� $ map:MapItemL���5I      �� *
Background+ �� $ map:MapItemL� 5K      _� 5L      ��5M      (� 5N      $	��300��6   .��5O      �� ��6   �� *Image+5P      5R      5T      5U      5W   	   -   5         5Y      P� 5Z   
    �@��
IsSelected . . �5[      �� 	 � ��

 � ���6)   5\      5^      5_       � DataContext 5c        ReadableAthens.ViewModel  5d         	MapCenter 5f      	   MapControl.Location	  5g   
    	  Latitude$ 37.98567Q�6    	  	Longitude$ 23.73822Q�6+   5w      .��5|      �  � RowDefinitions 5}      �� 5~      �� 5      $
��Auto �6   .+�5�      
   MapControl.Map
  -   5         
 Name$	 map��5�      $��2q�5�         MapControl.MapBase   	ZoomLevel$ 17.78Q�5�         MaxZoomLevel$ 20Q�5�         Center 5�      �� *	MapCenter+   	TileLayer 5�      ��  �� Source# [ $ CurrentItem�.+�5�          MapControl.MapItemsControl  #��[ 5�   	   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5�   	   ��5�   	   �� *
Pushpins+5�   	   5�      � 5�      $��1��6   $y�Visible=�6     � ColumnDefinitions  5�      �� 5�   
   �� 5�   
   $
��Auto �6   .+�5�      �� -   5        ! ��Name$! mouseLocation��5�      $��5q�6)   $��Bottom=�64   $��Segoe UI Mono)�6O   �� 5�      $��1��6   " �� Orientation$" 
Horizontal=�6#   $��Right=�6<   .+�5�      �� # � ToolTip$# 
Zoom Level��5�      $	��100��5�      $��Center=�5�      $ � SmallChange$
$ 0.01Q�5�      % � Minimum% 5�      �� *MinZoomLevel+& �� ElementName$	& map��' � Maximum' 5�      �� *MaxZoomLevel+$	& map��( � Value( 5�      �� *TargetZoomLevel+$	& map���� 5�   
   $# 
Tile Layer��5�      $��5q�5�      $��Bottom=�5�      ) �� DisplayMemberPath$) 
SourceName��5�      * �� SelectedIndex$* 0��5�      ��5�      �� # [ 5�   	   5�      r� 5�      -   5        + r�Name$+ sound��5�      , r� Source$), #App_Data/Sounds/crowd-talking-1.mp3?�5�      - r� LoadedBehavior$
- Play=�5�      . r� UnloadedBehavior$
. Play=�5�      $y�	Collapsed=�5�      5�      5�      