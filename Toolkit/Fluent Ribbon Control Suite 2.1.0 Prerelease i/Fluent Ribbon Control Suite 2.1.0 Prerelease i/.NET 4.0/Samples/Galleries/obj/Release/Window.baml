   M S B A M L   `   `   `  ���� M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent   Fluent.Sample.Galleries$   Fluent.Sample.Galleries.Window   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7Fluent$clr-namespace:Fluent;assembly=Fluent     -      Fluent.RibbonWindow   Name$  window�� � Title$ Fluent.Sample.Galleries��$	��500��$	��250�����	#FFEBEDF0 � 	Resources    middleDataItemTemplate �� Orientation �� Path �� Mode  largeDataItemTemplate � ToolTip��%�   &	        &	 �     �� .R��� ._��� $ 
Horizontal=�$
��Left=�.+��� $��UniformToFill=����� *Icon+�� $��10(�$��Center=����� $
 Text�$ OneWay=��� .R���  �� *Text+._��� ���� *	IconLarge+.��� .+�   Fluent.Ribbon     QuickAccessItems     Fluent.QuickAccessMenuItem   m� 	IsChecked . 	   Target	 �� 
 �� ElementName$
 buttonGreen��   . 	 �� $
 inRibbonGallery��   Tabs.    Fluent.RibbonTabItem     Header$	 Tab��   ReduceOrder$) #(A),(A),(A),(A),(A),(B),(B),(B),(B)��   Groups.    Fluent.RibbonGroupBox  -     Name$ A��   Header$ Without Grouping��.@�   Fluent.DropDownButton  -     Name$ buttonGreen��   Header$ DropDownButton��   Icon$ Images\Green.png��   	LargeIcon$ Images\GreenLarge.png��.@�   Fluent.Gallery  #���      MaxItemsInRow$ 3������ *	DataItems+   Fluent.MenuItem   m� Icon$ Images\Pink.png��$
��Pink��  $
 Pink��$ Images\Pink.png��$ Images\PinkLarge.png��.@�  .@��� $��Images\RedLarge.png��$
��None=��� $��Images\GreenLarge.png��$
��None=��� $��Images\BlueLarge.png��$
��None=�	   Fluent.InRibbonGallery	   	  Header$ InRibbonGallery�� 	  Icon$ Images\Gray.png�� 	  MinItemsInRow$ 3�� 	  MaxItemsInRow$ 8�� 	  	ItemWidth$ 40Q� 	  
ItemHeight$ 56Q�#���   	  
ResizeMode$
 Both=����� *	DataItems+ 	  Menu 
   Fluent.RibbonMenu
  .@�  $��Menu Item 1��  $��Menu Item 2��  -   $ B��$ With Grouping��.@�	  -    	 Name$ inRibbonGallery��$ Grouped��$ Images\Gray.png��$ 1��$ 5��$ 50Q�$ 18Q�#���     	  GroupBy$  Group��$
 Both=����� *	DataItems+! 	  Filters!    Fluent.GalleryGroupFilter  -   galleryFilterAll��"   Title$	" All��#   Groups$# Group A,Group B��  $" Group A��$# Group A��  $" Group B��$# Group B��