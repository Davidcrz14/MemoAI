   M S B A M L   `   `   `  ����
  MemoAI    MemoAI.Pages.InboxPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  	InboxPage��5         BackgroundColor N� 
Background# [  5      .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��0��6     SurfaceColor#��[ 6     BorderColor#��[ 5      $��0,0,0,1q�6;    �� Padding$ 32,24q�5      ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5      �� $
��📥��6    $��24(�6*   $��0,0,12,0q�68   $��Center=�6J   �� 5      $��Bandeja de Entrada��6    $��24(�6:   $��SemiBold"�6H     TextPrimary#��[ 5      $��Center=�6I   �� 5      $(��"Gestiona tus correos electrónicos��6    $��14(�6I     TextSecondary#��[ 5      $��Center=�5      $��24,0,0,0q�6:   5      �� 5       $��1��6   $ 
Horizontal=�6-   .+�5!      ��   PrimaryBlue#��[ 6    �� CornerRadius$ 8��6G   $
 16,8q�5"      $��0,0,12,0q�6+    � Cursor$
 Hand��6=   ._�5#      �� $��
+ Redactar��6$   $��14(�66   $��Medium"�6D   
�������5$   #   5%      �� 5&      -   5         ��Name$ RefreshButton��5&      
������ #��[ 6M   $��1q�5'      $ 8��60   $
 16,8q�6A   $
 Hand��6P   ._�5)      �� $��🔄 Actualizar��6$   $��14(�69   $��Medium"�6G   #��[ 5*   #   5+      5,      5-      5.      � 51   
   $��1��6    52      �� 53      $	��280 �6#   �� 54      $��* �6#   .+�58      �� $��0��6     SidebarColor#��[ 6%   #��[ 59      $��0,0,1,0q�6?   ._�5:      �� $��24,32,24,24q�6   .+�5;      �� $��FILTROS��6    $��12(�6/   $��Medium"�6=     TextTertiary#��[ 5<      $��0,0,0,16q�6J   �� 5?      -   5        $ InboxFilter��5?      #��[ 62   $ 12��6\   $ 16,12q�5@      $��0,0,0,8q�6,   $
 Hand��6=   ._�5B      �� .+�5C      �� $��📥 Recibidos��6(   $��14(�6<   $��Medium"�6J   
�������5D   '   �� 5E      -   5        	 ��Name$	 InboxCountText��5E   (   $��	24 nuevos��6@   $��12(�6Q   
�������
 J� Opacity$	
 0.8Q�5F   :   $��0,2,0,0q�6H   5G      5H      �� 5J      -   5        $ 
SentFilter��5J      #��[ 61   $ 12��6\   $ 16,12q�5K      $��0,0,0,8q�6,   $
 Hand��6=   ._�5M      �� .+�5N      �� $��📤 Enviados��6(   $��14(�6;   $��Medium"�6I   #��[ 5O   '   �� 5P      -   5        $	 SentCountText��5P   (   $��
12 correos��6?   $��12(�6Q   #��[ 5Q   '   $��0,2,0,0q�6S   5R      5S      �� 5U      #��[ 6   $ 12��6H   $ 16,12q�5V      $��0,0,0,8q�6,   $
 Hand��6=   ._�5W      �� .+�5X      �� $��⭐ Importantes��6(   $��14(�6=   $��Medium"�6K   #��[ 5Y   '   �� 5Z      $��	8 correos��6(   $��12(�69   #��[ 5[   '   $��0,2,0,0q�6S   5\      5]      �� 5a      #��[ 6   $ 12��6H   $ 16,12q�5b      $��0,0,0,32q�6,   $
 Hand��6>   ._�5c      �� .+�5d      �� $��🗑️ Papelera��6(   $��14(�6<   $��Medium"�6J   #��[ 5e   '   �� 5f      $��	3 correos��6(   $��12(�69   #��[ 5g   '   $��0,2,0,0q�6S   5h      5i      �� 5l      $��	ETIQUETAS��6    $��12(�61   $��Medium"�6?   #��[ 5m      $��0,0,0,16q�6J   �� 5o      #��[ 6   $ 8��6H   $
 12,8q�5p      $��0,0,0,6q�6+   $
 Hand��6<   ._�5q      �� $��🔴 Urgente��6$   $��12(�66   #��[ 5r   #   5s      �� 5u      #��[ 6   $ 8��6H   $
 12,8q�5v      $��0,0,0,6q�6+   $
 Hand��6<   ._�5w      �� $��💼 Trabajo��6$   $��12(�66   #��[ 5x   #   5y      �� 5{      #��[ 6   $ 8��6H   $
 12,8q�5|      $��0,0,0,6q�6+   $
 Hand��6<   ._�5}      �� $��👥 Personal��6$   $��12(�67   #��[ 5~   #   5      5�      5�      �� 5�      $��1��6   #��[ 6%   ._�5�      �� $
��Auto=�6   $��32,32,32,16q�6B   .��5�      �� -   5         ��Name$ EmailListPanel��5�   !   5�      5�      5�      5�      5�      5�      