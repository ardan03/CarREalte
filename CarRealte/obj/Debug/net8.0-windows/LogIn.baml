   M S B A M L   `   `   `  ����D  @CarRealte, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:CarRealte	CarRealte  5   	       CarRealte.LogIn   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:CarRealte     5   	     � Title$  LogIn��5   	   $	��400��6   $	��400��6$    � WindowStyle$
 None=�60   
������ .��5	      ��  �� CornerRadius$ 25��6   ��5
   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Color$ #456669��6    � Offset$ 0Q�6/   � 5      $ #8cb6ba��6   $ 1Q�6/   5      ._�5   
   �  � RowDefinitions 5      �� 5      $��70 �6    �� 5      .+�5      �� $#��Log In Retail Auto Aplication��6   $��Center=�6=   $��Center=�6Z   $��32(�6u   ���#000000$
��Bolt)�6�   $��40��6�   $	��394��6�   �� 5      $��1��6   $	��Top=�6&   $��Center=�6>   $	��132��6[   $	��280��6h   $��0 60 0 0q�6t   .+�5      �� $��Login��6   $��20(�6)   �� 5      -   5         ��Name$
 LogI��5      
������ $��2q�6A   
���   �$	��280��6i   $��	0 10 0 20q�6x   ��6�   �� *
Username+	 �� UpdateSourceTrigger$	 PropertyChanged=��� 5      $��Password��6   $��20(�6,   �� 5      -   5        $ Passwor��5      
������ $��2q�6D   
���   �$	��280��6l   $��0 10 0 0q�6{   ��6�   �� *
Password+$	 PropertyChanged=�5      �� 5      -   5        
 ��Name$
 LogInBtn��5   &   $��Log In��6   $��1��68   $��Bottom=�6E   $��50��6`   ��6l   �� *LoginCommand+��5      �� 5      $	 0,0&�6*   $	 1,1&�6;   .��5      � $ #6beffa��6'   $
 0.01Q�67   � 5       $ #00818c��6'   $	 0.3Q�67   � 5!      $ #00818c��6'   $	 0.7Q�67   � 5"      $ #6beffa��6'   $	 1.1Q�67   5#      ��5%      �� 5&       �� 
TargetType" ��6   .�5'      ��  �� Property � �� �� Value 5(      �� 5)   "    �� 
TargetType" ��62   .R�5*   &   �� #��z��6-   #��z��6W   #��z��6�   $ 	0 0 25 25��6�   ._�5+   *   �� $��Center=�6;   $��Center=�6X   5,   '   5-   #   5/      50      52      53      54      55      