   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   �   $  Cooperativeness.Documents.Editor   
DateDialog   6	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6`   7Fluent$clr-namespace:Fluent;assembly=Fluent     6�     � Title$
  Date��5       � Icon$ 
date16.ico��6   $	��280��6$   $	��320��61    � WindowStartupLocation$ CenterOwner=�6=    � ShowInTaskbar .   � 
ResizeMode$ NoResize=�6w   .��5      � ���	#7BFFFFFF.+�5   
      Fluent.Button  -   5        $��CancelButton��5   �      SizeDefinition/   )Fluent.Converters.SizeDefinitionConverter$ Middle 6      Icon$&  ../../Images/Common/cancel16.png��60      Header$ Cancel��6X   $��Right=�6h   $��	0,0,10,10q�6�   $��Bottom=�6�    �� IsCancel . 	 � ToolTip	 5         Fluent.ScreenTip  5      
   Title$
 Cancel��6#      Text$! Cancel and Close the Dialog��62      Image$&  ../../Images/Common/cancel48.png��6U   5        5	   
   -   5        $��OKButton��5	   �   $ Middle 6   $" ../../Images/Common/ok16.png��60   $ OK��6T   $��Right=�6`   $��	0,0,77,10q�6|   $��Bottom=�6�    �� 	IsDefault . 	 5
        5      $
 OK��6#   $&  Close the Dialog and Insert Date��6.   $" ../../Images/Common/ok48.png��6V   5      �� 5   
   -   5        $��ListBox1��5   '   $��10,10,10,44q�6   ���	#7BFFFFFF67   5      5      