   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   �   $  Cooperativeness.Documents.Editor   InsertLineDialog   6	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6$   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6f   7Fluent$clr-namespace:Fluent;assembly=Fluent     6�     � Title$  Insert Line��5       � Icon$ horizontalline16.ico��6   $	��105��65   $	��240��6B    � 
ResizeMode$ NoResize=�6N    � WindowStartupLocation$ CenterOwner=�6d    � ShowInTaskbar .  .��5      � ���	#7BFFFFFF.+�5   
      Fluent.Spinner  -   5        $��TextBox1��5   f      Fluent.RibbonControl   Header$ Width:��6      Format$
 0 px��6)      Minimum$ 4Q�67      Maximum$
 5000Q�6C   $��
10,10,10,0q�6R   $	��Top=�6v      Fluent.Button  5   
   -   5        $��CancelButton��5   �   	   SizeDefinition/   )Fluent.Converters.SizeDefinitionConverter$	 Middle 6   
   Icon$&
  ../../Images/Common/cancel16.png��60      Header$ Cancel��6X   $��Right=�6h   $��	0,0,10,10q�6�   $��Bottom=�6�    �� IsCancel .  � ToolTip 5         Fluent.ScreenTip  5         Title$ Cancel��6#      Text$! Cancel and Close the Dialog��62      Image$&  ../../Images/Common/cancel48.png��6U   5	        5
   
   -   5        $��OKButton��5
   �   $	 Middle 6   $"
 ../../Images/Common/ok16.png��60   $ OK��6T   $��Right=�6`   $��	0,0,77,10q�6|   $��Bottom=�6�    �� 	IsDefault .  5        5      $ OK��6#   $&  Close the Dialog and Insert Line��6.   $" ../../Images/Common/ok48.png��6V   5      5      5      