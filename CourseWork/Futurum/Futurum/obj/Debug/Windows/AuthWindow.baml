   M S B A M L   `   `   `  ����B  >Futurum, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Futurum.WindowsFuturum.Windows  5   	        Futurum.Windows.AuthWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Futurum.Windows     5   	   -   5          � Title$  
AuthWindow��5	   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�5
   	    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�5   	   $��Montserrat Alternates)�5   	   .��5      � ��5   
   �� 5       �� ImageSource$ /Resources/background.jpg��6    j� Stretch$ Uniform=�6A    j� 
AlignmentX$ Right=�6S    � ColumnDefinitions 5   
   �� 5      $��7* �6   �� 5      $��5* �6   .+�5   
   �� $��0��6   ���#17164D._�5      �� .+�5      �� $��/Resources/futurum.png��6   $	��200��68   �� 5      $��Center=�6   $��Center=�6:    �� Orientation$ 
Horizontal=�6U   .+�5      �� $��Center=�6!   .+�5      �� $��
Логин��6$   $��20��61   $��5q�6=   ���#FA45C36H   �� 5      $��Пароль��6$   $��20��62   $��5q�6>   ���#FA45C36I   5      �� 5      .+�5       �� 	 �� CornerRadius$	 12��6!   ���#FCD6FD$��1q�6H   $	��120��6\   $��Center=�6h   
 � UseLayoutRounding
 . $��5q�6�   ._�5!      �� -   5         ��Name$ TextBoxLogin��5!   &   $��0q�6<   .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ 	Collapsed=�6P   
������ $	��100��6�   5"      �� 5#      $	 12��6!   ���#FCD6FD$��1q�6H   $	��120��6\   $��Center=�6h   
 . $��5q�6�   ._�5$      G� -   5         G�Name$ PasswordBox��5$   *   $��0q�6?   $ 	Collapsed=�6S   
������ $	��100��6�   5%      5&      5'      �� 5(      $	 10��6   ���#F614C2$	��120��6@   $��24��6L   $��Center=�6X   
 . $��5q�6�   ._�5)      �� -   5         ��Name$ ButtonLogin��5)   2   ���#FCD6FD$��0q�6a   
������ $��
Войти��6�   $��24��6�   $��Center=�6�   $��10(�6�   5*      5+      5,      5-      5.      