   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5       Fluent.Sample.KeyTips"   Fluent.Sample.KeyTips.Window   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      7Fluent$clr-namespace:Fluent;assembly=Fluent     5        � Title$  Fluent.Sample.KeyTips��5      $	��500��5      $	��250��5      ���	#FFEBEDF0.��5	      � .+�5
         Fluent.Ribbon     QuickAccessItems 5          Fluent.QuickAccessMenuItem  5       m� 	IsChecked .    Target 5      ��  �� ElementName$ 	buttonRed��  5       .  5      �� $ 
buttonGray��   Tabs. 5         Fluent.RibbonTabItem     Header$ Auto Placement��6      Fluent.KeyTip   Keys$ A��5         ReduceOrder$ ZC,ZC,ZC��5      	   Groups.	 5         Fluent.RibbonGroupBox  -   5        
  Name$
 ZC��5         Header$ Group��5      $ ZC��5      .@�5         Fluent.SplitButton  -   5          Name$ 	buttonRed��5         Fluent.DropDownButton   Header$	 Red��5       $ R��5!         Icon$ Images\Red.png��5"         	LargeIcon$ Images\RedLarge.png��5#      %   Fluent.RibbonAttachedProperties   RibbonSizeDefinition$ Large��5$      .@�5%      	   Fluent.MenuItem	  $
��Pink��6   $ P��5&       m� Icon$ Images\Pink.png��5'      	  5(      $	��Red��6   $ R��5)      $ Images\Red.png��5*      .@�5+   	   	  $��Orange��6   $ O��5,      $ Images\Orange.png��5-      5.   	   5/      
   Fluent.Button
  50      -   5         
 Name$ 
buttonGray��50       
  Header$
 Grey��51      $ G��52       
  Icon$ Images\Gray.png��53       
  	LargeIcon$ Images\GrayLarge.png��54      $ Large��55      
  56      $ Orange��6   $ O��57      $ Images\Orange.png��58      $ Images\OrangeLarge.png��59      $ Large��5:      
  5;      $
 Pink��6   $ P��5<      $ Images\Pink.png��5=      $ Images\PinkLarge.png��5>      $ Large��5?      
  5@      $ Yellow��6   $ Y��5A      $ Images\Yellow.png��5B      $ Images\YellowLarge.png��5C      $ Large��5D      
  5E      $ Brown��6   $ B��5F      $ Images\Brown.png��5G      $ Images\BrownLarge.png��5H      $ Large��5I      
  5J      $
 Gray��6   $ X1��5K      $ Images\Gray.png��5L      $ Images\GrayLarge.png��5M      $ Middle��5N      
  5O      $
 Gray��6   $ X2��5P      $ Images\Gray.png��5Q      $ Images\GrayLarge.png��5R      $ Middle��5S      
  5T      $
 Gray��6   $ X3��5U      $ Images\Gray.png��5V      $ Images\GrayLarge.png��5W      $ Middle��5X      5Y      5Z        5c      $ Custom Placement��6   $ C��5d      .	 5e        $ Group��6   .@�5f      
  $ Center��6   $ C��5g      $ Images\Green.png��5h      $ Images\GreenLarge.png��5i         AutoPlacement .     HorizontalAlignment$ Center=�5k         VerticalAlignment$ Center=�5l      
  5m      $
 Left��6   $ L��5n      $ Images\Gray.png��5o      $ Images\GrayLarge.png��5p       .  $
 Left=�5r      $ Center=�5s      
  5t      $	 Top��6   $ T��5u      $ Images\Yellow.png��5v      $ Images\YellowLarge.png��5w       .  $ Center=�5y      $	 Top=�5z      5{      5|         Menu 5         Fluent.Backstage  5�         Content. 5�          Fluent.BackstageTabControl  .@�5�         Fluent.BackstageTabItem     Header$	 New��6    $ N��5�        5�      $ Print��6    $ P��5�       
  5�      $
 Blue��6   $ B��5�      $ Images\Blue.png��5�      5�      5�      5�      �� 5�      $(��"* Press Alt or F10 to show KeyTips��6   $��Bottom=�5�      $��10q�5�      5�      5�      