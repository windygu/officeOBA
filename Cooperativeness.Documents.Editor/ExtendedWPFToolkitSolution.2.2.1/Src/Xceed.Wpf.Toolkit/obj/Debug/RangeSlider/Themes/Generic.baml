   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      X TXceed.Wpf.Toolkit, Version=2.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4C&clr-namespace:Xceed.Wpf.Toolkit.ThemesXceed.Wpf.Toolkit.Themes 5      5clr-namespace:Xceed.Wpf.ToolkitXceed.Wpf.Toolkit 5      K*clr-namespace:Xceed.Wpf.Toolkit.ConvertersXceed.Wpf.Toolkit.Converters 5      U/clr-namespace:Xceed.Wpf.Toolkit.Core.Converters!Xceed.Wpf.Toolkit.Core.Converters 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089<   6Xceed.Wpf.Toolkit.Converters.SliderThumbWidthConverter   SliderThumbWidthConverterG  AXceed.Wpf.Toolkit.Core.Converters.SolidColorBrushToColorConverter # SolidColorBrushToColorConverter  NormalThumbFillBackground  �� 
StartPoint �� EndPoint � Color � Offset   MouseOverThumbFillBackground  PressedThumbFillBackground  SliderBorderBrush  SliderVerticalBorderBrush  DefaultRangeStyle �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 J� Opacity  LowerThumbTemplate
 ��Name �� CornerRadius J� SnapsToDevicePixels �� RelativeSource �� AncestorType#  Xceed.Wpf.Toolkit.RangeSlider �� Path �� TargetNullValue � ToolTip �� StringFormat �� Triggers P� Property P� Value �� 
TargetName ^� 
Conditions �� Binding �� Value 	 HigherThumbTemplate 
 LowerSliderTemplate � RowDefinitions ]�Name ]� Thumb n�Name  HigherSliderTemplate  VerticalRangeSlider �� ElementName �� 	Converter  �� ConverterParameter! � ColumnDefinitions" ��Name#   LowerRangeWidth$   LowerRangeBackground%   
RangeWidth&   RangeBackground'   HigherRangeWidth(   HigherRangeBackground) ��Name* �� Orientation+   Minimum, � Minimum-   Maximum. � Maximum/ � Value0 �� Mode1 �� Triggers�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .sys&clr-namespace:System;assembly=mscorlib  5      1themes&clr-namespace:Xceed.Wpf.Toolkit.Themes  5      )localclr-namespace:Xceed.Wpf.Toolkit  5      3conv*clr-namespace:Xceed.Wpf.Toolkit.Converters  5      <coreConv/clr-namespace:Xceed.Wpf.Toolkit.Core.Converters  5      %�4  &	        &	      &	 &     &	     &	 �    &	 �    &	 l    &	     &	 �    7  7  7  &		     7  7  7  &	
 '    7  &	 �    7 	 &	     7   7   7  7  7  7  7  7  7  7  7  7  '  �,    7   7   7  7  7  7  7 
 7  7     5      6$     5      6.   �� 5      $  0.5,0&�5      $ 0.5,1&�5      .��5      � $ White��6   $ 0Q�5       � 5!      $ 	#FFEBEBEB��6   $	 0.5Q�5"      � 5#      $ 	#FFD6D6D6��6   $ 1Q�5$      5%      �� 5'      $  0.5,0&�5(      $ 0.5,1&�5)      .��5*      � $ White��6   $ 0Q�5+      � 5,      $ 	#FFBBE3F9��6   $	 0.5Q�5-      � 5.      $ 	#FFB1E0F8��6   $ 1Q�5/      50      �� 52      $  0.5,0&�53      $ 0.5,1&�54      .��55      � $ White��6   $ 0Q�56      � 57      $ 	#FF5DB2E0��6   $	 0.5Q�58      � 59      $ 	#FF4F93BD��6   $ 1Q�5:      5;      �� 5=      $  0.5,0&�5>      $ 0.5,1&�5?      .��5@      � $ 	#FFB2B5B3��6   $ 0Q�5A      � 5B      $ 	#FFFAFAFA��6   $ 1Q�5C      5D      �� 5F      $  0,0.5&�5G      $ 1,0.5&�5H      .��5I      � $ 	#FFB2B5B3��6   $ 0Q�5J      � 5K      $ 	#FFFAFAFA��6   $ 1Q�5L      5M      �� 5Q      " ��5R      .�5S      ��  � �� 5T      �� 5U      " ��6   .R�5V      � .+�5W      �� $ 
MainBorder��6   
������ $	 1Q�5Y      5Z      5[      5]   	   5^      �� 5c      " n�5d      .R�5e      � .+�5f      �� $
 BackgroundFadingBorder��6   
���   �5g      �� 5h      $
 BackgroundBorder��6   ���	#FF929292$��1q�5j      $ 1��5k      ._�5l      �� $ 
MainBorder��6   $��1��5n      
�������$��9��5p      $��20��5q      $	 1Q�5r       . ��5m      ��  �� "  $ LowerThumbBackground�8    5s      ��  �� "  $ 
LowerValue�$ 	{0:00.00}��5t      5u      5v   	    5w      P� 5x       �@J�IsMouseOver . . �5z      �� $ 
MainBorder��5{       �@J�Opacity$	 0.9Q�5|      5}      P� 5~       �@J�IsMouseCaptureWithin . . �5�      �� $ 
MainBorder��5�       �@J�Opacity$	 0.8Q�5�      5�      ^� 5�       5�      �� 5�       6   ��  �� "  $ LowerThumbBackground� 5�      Z� �� 5�       6   ��  �� *Self+$ IsMouseOver� True5�      .0�5�      �� $ 
MainBorder��5�       �@J�Opacity$ 1Q�5�      �� 5�      $ BackgroundBorder��5�       � �� �	#FF3C7FB15�      �� 5�      $ 
MainBorder��5�      8   � ��5�      5�      ^� 5�       5�      �� 5�       6   ��  �� "  $ LowerThumbBackground� 5�      Z� �� 5�       6   ��  �� *Self+$ IsMouseCaptureWithin� True5�      .0�5�      �� $ BackgroundBorder��5�       � �� �	#FF2C628B5�      �� 5�      $ 
MainBorder��5�      8   � ��5�      5�      P� 5�       � {� .  . �5�      �� $ BackgroundBorder��5�       � �� �	#FFD7D7D75�      �� 5�      $ 
MainBorder��5�       � �� �	#FFF4F4F45�      �� 5�      $ 
MainBorder��5�       � �� �	#FFD7D7D75�      5�      5�      �� 5�      " n�5�      .R�5�      � .+�5�      �� $
 BackgroundFadingBorder��6   
���   �5�      �� 5�      $
 BackgroundBorder��6   ���	#FF929292$��1q�5�      $ 1��5�      ._�5�      �� $ 
MainBorder��6   $��1��5�      
�������$��9��5�      $��20��5�       . ��5�      ��  �� "  $ HigherThumbBackground�8    5�      ��  �� "  $ HigherValue�$ 	{0:00.00}��5�      5�      5�   	    5�      P� 5�       �@J�IsMouseOver . . �5�      �� $ 
MainBorder��5�       �@J�Opacity$	 0.9Q�5�      5�      P� 5�       �@J�IsMouseCaptureWithin . . �5�      �� $ 
MainBorder��5�       �@J�Opacity$	 0.8Q�5�      5�      ^� 5�       5�      �� 5�       6   ��  �� "  $ HigherThumbBackground� 5�      Z� �� 5�       6   ��  �� *Self+$ IsMouseOver� True5�      .0�5�      �� $ 
MainBorder��5�       �@J�Opacity$ 1Q�5�      �� 5�      $ BackgroundBorder��5�       � �� �	#FF3C7FB15�      �� 5�      $ 
MainBorder��5�      8   � ��5�      5�      ^� 5�       5�      �� 5�       6   ��  �� "  $ HigherThumbBackground� 5�      Z� �� 5�       6   ��  �� *Self+$ IsMouseCaptureWithin� True5�      .0�5�      �� $ BackgroundBorder��5�       � �� �	#FF2C628B5�      �� 5�      $ 
MainBorder��5�      8   � ��5�      5�      P� 5�       � {� .  . �5�      �� $ BackgroundBorder��5�       � �� �	#FFD7D7D75�      �� 5�      $ 
MainBorder��5�       � �� �	#FFF4F4F45�      �� 5�      $ 
MainBorder��5�       � �� �	#FFD7D7D75      5     5     �� 5     " ��5	     .R�5
     ��  . #��z��5     #��z��5     ._�5     �  5     �� 5     $
��Auto �6   �� 5     $
��Auto �6   #��z��5     �� 5     $
��Auto �6   .+�5     ]� $ 
PART_Track��6   $��1��5      5     n� 5     $ Thumb��6   8��  5     5     5     5  	   5     �� 5$     " ��5%     .R�5&     ��  . #��z��5'     #��z��5(     ._�5)     �  5*     �� 5+     $
��Auto �6   �� 5,     $
��Auto �6   #��z��5-     �� 5.     $
��Auto �6   .+�51     ]� $ 
PART_Track��6   $��1��52      53     n� 54     $ Thumb��6   8��  55     57     58     59  	   5:     �� 5?     "  5@     .R�5A     � $��50��6    5D     �� 5E     ��6   �� *.+$ PART_HigherSlider��8   $  1���� 5F     $
��Auto �6   �� 5G     $
��Auto �6   �� 5H     $
��Auto �6   �� 5I     ��6   �� *.+$ PART_LowerSlider��8  $  1��! 5L     �� 5M     $
��Auto �6   �� 5N     $
��Auto �6   $��50��5O     .+�5R     �� $��1��6   $��1��5S     $��3��5T     $��1q�5U     8�� ���	#FFE7EAEA$��Stretch=�5X     $��Center=�5Y     $��4��5Z     �� 5\     $" PART_LowerRange��6   #��z# 5]     $��15��5^     $��1��5_     $��3��5`     #��z$ 5a      . ��5b     �� *LowerRangeStyle+ �� *TemplatedParent+8  5c     �� 5e     #��z% 6   $��15��5f     $��2��5g     $��1��5h     #��z& 5i      . ��5j     �� *
RangeStyle+ �� *TemplatedParent+8  5k     �� 5m     $" PART_HigherRange��6   #��z' 5n     $��15��5o     $��1��5p     $��1��5q     #��z( 5r      . ��5s     �� *HigherRangeStyle+ �� *TemplatedParent+8  5t     �� 5w     $) PART_LowerSlider��6   $��1��5x     $* Vertical=�5y     $��5��5z     #, z+ 5{     #. z- 5|     / 5}     ��  �� "  $0 TwoWay=�$ 
LowerValue�$ 	{0:00.00}����5~     �� 5     " ��6!   .R�5�     ��  . #��z��5�     #��z��5�     ._�5�     � .+�5�     ]� $ 
PART_Track��6     5�     n� 5�      $ Thumb��6&   ��5�  #   �� 5�  &   " n�66   .R�5�  )   � .+�5�  ,   �� $
 BackgroundFadingBorder��63   
���   �$��22��5�  3   �� 5�  ,   $
 BackgroundBorder��63   ���	#FF929292$��1q�5�  3   $��22��5�  3   $ 1��5�  3   ._�5�  /   �� $ 
MainBorder��69   $��1��5�  9   
�������$��20��5�  9   $��9��5�  9    . ��5�  9   ��  �� "  $ LowerThumbBackground�8   5�  9   ��  �� "  $ 
LowerValue�$ 	{0:00.00}��5�  9   5�  -   5�  *    5�  )   P� 5�  ,    �@J�IsMouseOver . . �5�  /   �� $ 
MainBorder��5�  6    �@J�Opacity$	 0.9Q�5�  6   5�  -   P� 5�  ,    �@J�IsMouseCaptureWithin . . �5�  /   �� $ 
MainBorder��5�  6    �@J�Opacity$	 0.8Q�5�  6   5�  -   ^� 5�  ,    5�  /   �� 5�  2    6<   ��  �� "  $ LowerThumbBackground� 5�  <   Z� �� 5�  2    6<   ��  �� *Self+$ IsMouseOver� True5�  <   .0�5�  /   �� $ 
MainBorder��5�  6    �@J�Opacity$ 1Q�5�  6   �� 5�  /   $ BackgroundBorder��5�  6    � �� �	#FF3C7FB15�  6   �� 5�  /   $ 
MainBorder��5�  6   8   � ��5�  6   5�  -   ^� 5�  ,    5�  /   �� 5�  2    6<   ��  �� "  $ LowerThumbBackground� 5�  <   Z� �� 5�  2    6<   ��  �� *Self+$ IsMouseCaptureWithin� True5�  <   .0�5�  /   �� $ BackgroundBorder��5�  6    � �� �	#FF2C628B5�  6   �� 5�  /   $ 
MainBorder��5�  6   8   � ��5�  6   5�  -   P� 5�  ,    � {� .  . �5�  /   �� $ BackgroundBorder��5�  6    � �� �	#FFD7D7D75�  6   �� 5�  /   $ 
MainBorder��5�  6    � �� �	#FFF4F4F45�  6   �� 5�  /   $ 
MainBorder��5�  6    � �� �	#FFD7D7D75�  6   5�  -   5�  '   5�  !   5�     5�     5�     5�     5�     �� 5�     $) PART_HigherSlider��6   $��1��5�     $��5��5�     $* Vertical=�5�     #, z+ 5�     #. z- 5�     / 5�     ��  �� "  $0 TwoWay=�$ HigherValue�$ 	{0:00.00}����5�     �� 5�     " ��6!   .R�5�     ��  . #��z��5�     #��z��5�     ._�5�     � .+�5�     ]� $ 
PART_Track��6     5�     n� 5�      $ Thumb��6&   ��5�  #   �� 5�  &   " n�66   .R�5�  )   � .+�5�  ,   �� $
 BackgroundFadingBorder��63   $��22��5�  3   
���   �5�  3   �� 5�  ,   $
 BackgroundBorder��63   ���	#FF929292$��1q�5�  3   $��22��5�  3   $ 1��5�  3   ._�5�  /   �� $ 
MainBorder��69   $��1��5�  9   
�������$��20��5  9   $��9��5  9    . ��5�  9   ��  �� "  $ HigherThumbBackground�8 	  5  9   ��  �� "  $ HigherValue�$ 	{0:00.00}��5  9   5  -   5  *    5  )   P� 5  ,    �@J�IsMouseOver . . �5
  /   �� $ 
MainBorder��5  6    �@J�Opacity$	 0.9Q�5  6   5  -   P� 5  ,    �@J�IsMouseCaptureWithin . . �5  /   �� $ 
MainBorder��5  6    �@J�Opacity$	 0.8Q�5  6   5  -   ^� 5  ,    5  /   �� 5  2    6<   ��  �� "  $ HigherThumbBackground� 5  <   Z� �� 5  2    6<   ��  �� *Self+$ IsMouseOver� True5  <   .0�5  /   �� $ 
MainBorder��5  6    �@J�Opacity$ 1Q�5  6   �� 5  /   $ BackgroundBorder��5  6    � �� �	#FF3C7FB15   6   �� 5!  /   $ 
MainBorder��5"  6   8 
  � ��5#  6   5$  -   ^� 5%  ,    5&  /   �� 5'  2    6<   ��  �� "  $ HigherThumbBackground� 5(  <   Z� �� 5)  2    6<   ��  �� *Self+$ IsMouseCaptureWithin� True5*  <   .0�5,  /   �� $ BackgroundBorder��5-  6    � �� �	#FF2C628B5.  6   �� 5/  /   $ 
MainBorder��50  6   8   � ��51  6   52  -   P� 54  ,    � {� .  . �56  /   �� $ BackgroundBorder��57  6    � �� �	#FFD7D7D758  6   �� 59  /   $ 
MainBorder��5:  6    � �� �	#FFF4F4F45;  6   �� 5<  /   $ 
MainBorder��5=  6    � �� �	#FFD7D7D75>  6   5?  -   5A  '   5C  !   5E     5F     5G     5H     5J     5K  	   5L     �� 5Q     "  6   .�5R     ��  � �� 5S     �� 5T     "  6   .R�5U     �  5V     �� 5W     $
��Auto �6%   �� 5X     $
��Auto �6%   #��z��5Y  %   �� 5Z     $
��Auto �6%   �� 5[     $
��Auto �6%   ! 5`     �� 5a     ��6(   �� *.+$ PART_LowerSlider��8   $  0���� 5b     $
��Auto �6(   �� 5c     $
��Auto �6(   �� 5d     $
��Auto �6(   �� 5e     ��6(   �� *.+$ PART_HigherSlider��8  $  0��.+�5h     �� $��1��6   $��1��5i     $��3��5j     $��1q�5k     8�� ���	#FFE7EAEA$��Center=�5n     $��4��5o     �� 5q     $" PART_LowerRange��6!   #��z# 5r  !   $��1��5s  !   $��1��5t  !   #��z$ 5u  !    . ��5v  !   �� *LowerRangeStyle+ �� *TemplatedParent+8  5w  !   �� 5y     #��z% 6!   $��1��5z  !   $��2��5{  !   #��z& 5|  !    . ��5}  !   �� *
RangeStyle+ �� *TemplatedParent+8  5~  !   �� 5�     $" PART_HigherRange��6!   #��z' 5�  !   $��1��5�  !   $��3��5�  !   #��z( 5�  !    . ��5�  !   �� *HigherRangeStyle+ �� *TemplatedParent+8  5�  !   �� 5�     $) PART_LowerSlider��6   $��1��5�     $��5��5�     8�� #, z+ 5�     #. z- 5�     / 5�     ��  �� "  $0 TwoWay=�$ 
LowerValue�$ 	{0:00.00}��5�     �� 5�     $) PART_HigherSlider��6   $��1��5�     $��5��5�     8�� #, z+ 5�     #. z- 5�     / 5�     ��  �� "  $0 TwoWay=�$ HigherValue�$ 	{0:00.00}��5�     5�     5�     5�  	   1 5�     P� 5�      �@ Orientation$ Vertical=�5�     . �5�     ��  � ��8  5�     5�     5�     5�     