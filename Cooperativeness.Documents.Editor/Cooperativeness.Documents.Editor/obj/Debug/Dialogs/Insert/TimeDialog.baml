   M S B A M L   `   `   `  ����M  IFluent, Version=2.1.0.0, Culture=neutral, PublicKeyToken=3e436e32a8c5546f/$clr-namespace:Fluent;assembly=FluentFluent  5   �   $  Cooperativeness.Documents.Editor   
TimeDialog   6	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    6   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     6`   7Fluent$clr-namespace:Fluent;assembly=Fluent     6�     � Title$
  Time��5       � Icon$ 
time16.ico��6   $	��150��6$   $	��240��61    � 
ResizeMode$ NoResize=�6=    � WindowStartupLocation$ CenterOwner=�6S   .��5      � ���	#7BFFFFFF.+�5   
      Fluent.Button  -   5        $��CancelButton��5   �      SizeDefinition/   )Fluent.Converters.SizeDefinitionConverter$ Middle 6      Icon$&  ../../Images/Common/cancel16.png��60      Header$ Cancel��6X   $��Right=�6h   $��	0,0,10,10q�6�   $��Bottom=�6�    �� IsCancel .  � ToolTip 5         Fluent.ScreenTip  5      	   Title$	 Cancel��6#   
   Text$!
 Cancel and Close the Dialog��62      Image$&  ../../Images/Common/cancel48.png��6U   5        5	   
   -   5        $��OKButton��5	   �   $ Middle 6   $" ../../Images/Common/ok16.png��60   $ OK��6T   $��Right=�6`   $��	0,0,77,10q�6|   $��Bottom=�6�    �� 	IsDefault .  5
        5      $	 OK��6#   $&
  Close the Dialog and Insert Time��6.   $" ../../Images/Common/ok48.png��6V   5      � 5   
   -   5        $��Grid1��5   $   $��10,10,10,44q�6   .+�5         Fluent.RadioButton  -   5        $��RadioButton12��5   `      Header$ 12 Hour��6!   
���   �$
��Left=�6E   $	��Top=�6u    d� 	IsChecked$
 TrueY�6�      Fluent.CheckBox  5      -   5        $��AMPMCheckBox��5   n      Header$ AM/PM��6   
���   �$
��Left=�6@   $��	14,24,0,0q�6[   $	��Top=�6�   $
 TrueY�6�     5      -   5        $��RadioButton24��5   r   $ 24 Hour��6!   
���   �$
��Left=�6E   $��6,48,0,0q�6`   $	��Top=�6�     5      -   5        $��SecCheckBox��5   m   $	 Sec��6   
���   �$
��Left=�6>   $��
159,48,0,0q�6Y   $	��Top=�6�   5      5      5      