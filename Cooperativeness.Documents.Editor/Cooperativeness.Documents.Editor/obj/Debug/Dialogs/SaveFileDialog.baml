   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   �   $  Cooperativeness.Documents.Editor   SaveFileDialog   6	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6"   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6d   7Fluent$clr-namespace:Fluent;assembly=Fluent     6�   -   5        $��SaveFileDialog��5   r     � Title$  Save Document��6    � WindowStyle$ 
ToolWindow=�6    � WindowStartupLocation$ CenterScreen=�64   $	��320��6Y   $	��480��6f    � 
ResizeMode$ 	CanResize=�6�    � ShowInTaskbar .  .��5      � ���	#7BFFFFFF.+�5   
   �� -   5        $��Label1��5   m   $��Center=�6   $	��Top=�64   $��16(�6S   $��28��6a   $	��Top=�6{    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ White��6#      ShadowDepth$ 0Q�61   .��5       Do you want to save |FileName|5      � 5	   
   -   5        $��Grid1��5	   !   $��0,0,0,44q�6   ���	#3FFFFFFF.+�5
      �� -   5        $��Label2��5
       $��28��6   $��14(�6.   $��0,34,0,0q�6<   $	��Top=�6N    5        5      $ White��6'   $ 0Q�65   .��5       
Preview:5      �� 5      -   5        $��RichTextBox1��5   W    �� 
IsReadOnly . 	 �� IsDocumentEnabled	 . $��0,60,0,0q�6E   6W   5         Fluent.Button  5   
   -   5        $��	YesButton��5   r   
   SizeDefinition/   )Fluent.Converters.SizeDefinitionConverter$
 Middle 6      Icon$ ../Images/Common/ok16.png��60      Header$	 Yes��6Q   $��
0,0,127,10q�6^   $��Bottom=�6�   $��Right=�6�   $��0��6�    � ToolTip 5         Fluent.ScreenTip  5         Title$	 Yes��6#      Text$ Close the Dialog and Save��6/      Image$ ../Images/Common/ok48.png��6P   5        5   
   -   5        $��NoButton��5   O   $
 Middle 6   $ No��60   $��	0,0,77,10q�6<   $��Bottom=�6_   $��Right=�6z   $��1��6�    5        5      $ No��6#   $% Close the Dialog and Don't Save��6.   5        5   
   -   5        $��CancelButton��5   x   $
 Middle 6   $# ../Images/Common/cancel16.png��60   $ Cancel��6U   $��	0,0,10,10q�6e   $��Bottom=�6�   $��Right=�6�    �� 	IsDefault . $��2��6�    5        5      $ Cancel��6#   $! Cancel and Close the Dialog��62   $# ../Images/Common/cancel48.png��6U   5       5!      5"      