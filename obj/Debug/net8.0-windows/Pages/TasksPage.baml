   M S B A M L   `   `   `  ����
  MemoAI    MemoAI.Pages.TasksPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  	TasksPage��5         BackgroundColor N� 
Background# [  5      .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6     SurfaceColor#��[ 6     BorderColor#��[ 5      $��0,0,0,1q�6;    �� Padding$ 32,24q�5      ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��Auto �6'   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6-   $��Center=�6F   .+�5      �� $
��📋��6    $��24(�6*   $��0,0,12,0q�68   $��Center=�6J   �� 5      $��Gestión de Tareas��6    $��24(�69   $��SemiBold"�6G     TextPrimary#��[ 5      $��Center=�6I   5      �� 5      $��1��6   $ 
Horizontal=�6-   .+�5       �� -   5          PrimaryBlue#��[ 5        �� CornerRadius$ 8��6G   $
 16,8q�5!      $��0,0,12,0q�6+    � Cursor$
 Hand��6=   ._�5#      �� $��+ Nueva Tarea��6$   $��14(�69   $��Medium"�6G   
�������5$   #   5%      �� 5&      
������ #��[ 66   $��1q�5'      $ 8��60   $
 16,8q�6A   $
 Hand��6P   ._�5)      �� $��
← Volver��6$   $��14(�64   $��Medium"�6B   #��[ 5*   #   5+      �� 5,      
������ #��[ 66   $��1q�5-      $ 8��60   $
 16,8q�6A   $
 Hand��6P   ._�5.      �� $��
← Volver��6$   $��14(�64   $��Medium"�6B   #��[ 5/   #   50      51      52      53      � 56   
   $��1��6    57      �� 58      $	��300 �6#   �� 59      $��* �6#   �� 5:      $	��350 �6#   .+�5>      �� $��0��6     SidebarColor#��[ 6%   #��[ 5?      $��0,0,1,0q�6?   ._�5@      �� $��24,32,24,24q�6   .+�5A      �� $��FILTROS��6    $��12(�6/   $��Medium"�6=     TextTertiary#��[ 5B      $��0,0,0,16q�6J   �� 5D      #��[ 6   $ 8��6G   $ 16,12q�5E      $��0,0,0,8q�6,   $
 Hand��6=   ._�5F      �� $��Todas las tareas��6$   $��14(�6<   $��Medium"�6J   
�������5G   #   5H      �� 5J      
������ $ 8��66   $ 16,12q�5K      $��0,0,0,8q�6,   $
 Hand��6=   ._�5L      �� $��
Pendientes��6$   $��14(�66   #��[ 5M   #   5N      �� 5P      
������ $ 8��66   $ 16,12q�5Q      $��0,0,0,8q�6,   $
 Hand��6=   ._�5R      �� $��En progreso��6$   $��14(�67   #��[ 5S   #   5T      �� 5V      
������ $ 8��66   $ 16,12q�5W      $��0,0,0,32q�6,   $
 Hand��6>   ._�5X      �� $��Completadas��6$   $��14(�67   #��[ 5Y   #   5Z      �� 5\      $��	PRIORIDAD��6    $��12(�61   $��Medium"�6?   #��[ 5]      $��0,0,0,16q�6J   �� 5_      
������ $ 8��66   $ 16,12q�5`      $��0,0,0,8q�6,   $
 Hand��6=   ._�5a      �� $ 
Horizontal=�6%   .+�5b      A� $��8��6&   $��8��60    
 RedTag#��[ 6;   $��0,0,8,0q�6Z   �� 5c      $
��Alta��6(   $��14(�64   #��[ 5d   '   5e      5f      �� 5h      
������ $ 8��66   $ 16,12q�5i      $��0,0,0,8q�6,   $
 Hand��6=   ._�5j      �� $ 
Horizontal=�6%   .+�5k      A� $��8��6&   $��8��60     	OrangeTag#��[ 6;   $��0,0,8,0q�6]   �� 5l      $��Media��6(   $��14(�65   #��[ 5m   '   5n      5o      �� 5q      
������ $ 8��66   $ 16,12q�5r      $��0,0,0,8q�6,   $
 Hand��6=   ._�5s      �� $ 
Horizontal=�6%   .+�5t      A� $��8��6&   $��8��60    	 GreenTag#��[	 6;   $��0,0,8,0q�6\   �� 5u      $
��Baja��6(   $��14(�64   #��[ 5v   '   5w      5x      5y      5z      �� 5}      $��1��6   #��[ 6%   ._�5~      �� $
��Auto=�6   .��5      �� $��32,32,32,24q�6!   .+�5�      �� #��[ 6!   #��[ 5�       $��1q�6K   $ 12��5�       $ 24,20q�62   $��0,0,0,16q�6B   ._�5�      �  5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��6+   $	��Top=�6;   $��0,4,16,0q�6S   �� 5�   "   $��1��6-   .+�5�   &   �� $"��Revisar propuesta de cliente��60   $��16(�6T   $��Medium"�6b   #��[ 5�   /   $��0,0,0,8q�6Y   �� 5�   &   $I��CAnalizar los requerimientos del nuevo proyecto y preparar respuesta��60   $��14(�5�   /    
 TextSecondary#��[
 6=   $
��Wrap=�5�   /   $��0,0,0,12q�6C   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� #��[ 61   $ 12��6V   $	 8,4q�5�   0   $��0,0,8,0q�6>   ._�5�   .   �� $
��Alta��68   $��11(�6D   $��Medium"�6R   
�������5�   7   5�   +   �� 5�   *   $��
Vence: Hoy��64   $��12(�6F   #��[ 5�   3   $��Center=�5�   3   5�   '   5�   #   �� 5�   "   $��2��6)   
������ $ 6��5�   (   $ 8q�69   $
 Hand��6E   ._�5�   &   �� $	��⋯��60   $��16(�69   $
��Bold"�6G   #��[ 5�   /   5�   #   5�      5�      �� 5�      #��[ 6!   #��[ 5�       $��1q�6K   $ 12��5�       $ 24,20q�62   $��0,0,0,16q�6B   ._�5�      �  5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��6+   $	��Top=�6;   $��0,4,16,0q�6S   �� 5�   "   $��1��6-   .+�5�   &   �� $,��&Actualizar documentación del proyecto��60   $��16(�6]   $��Medium"�6k   #��[ 5�   /   $��0,0,0,8q�6Y   �� 5�   &   $B��<Incluir las nuevas funcionalidades implementadas esta semana��60   $��14(�5�   /   #��[
 6=   $
��Wrap=�5�   /   $��0,0,0,12q�6C   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� #��[ 61   $ 12��6Y   $	 8,4q�5�   0   $��0,0,8,0q�6>   ._�5�   .   �� $��Media��68   $��11(�6E   $��Medium"�6S   
�������5�   7   5�   +   �� 5�   *   $��Vence: Mañana��64   $��12(�6I   #��[ 5�   3   $��Center=�5�   3   5�   '   5�   #   �� 5�   "   $��2��6)   
������ $ 6��5�   (   $ 8q�69   $
 Hand��6E   ._�5�   &   �� $	��⋯��60   $��16(�69   $
��Bold"�6G   #��[ 5�   /   5�   #   5�      5�      �� 5�      #��[ 6!   #��[ 5�       $��1q�6K   $ 12��5�       $ 24,20q�62   $��0,0,0,16q�6B   ._�5�      �  5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   �� 5�   &   $
��Auto �67   .+�5�   "   �� $��0��6+   $	��Top=�6;   $��0,4,16,0q�6S    d� 	IsChecked$
 TrueY�6e   �� 5�   "   $��1��6-   .+�5�   &   �� $ ��Reunión de equipo semanal��60   $��16(�6Q   $��Medium"�6_   #��[
 5�   /   $��0,0,0,8q�6[   $��Strikethrough{�5�   /   �� 5�   &   $B��<Revisar el progreso del sprint y planificar próximas tareas��60   $��14(�5�   /   #��[ 6=   $
��Wrap=�5�   /   $��0,0,0,12q�6C   �� 5�   &   $ 
Horizontal=�61   .+�5�   *   �� #��[	 61   $ 12��6X   $	 8,4q�5�   0   $��0,0,8,0q�6>   ._�5�   .   �� $��
Completada��68   $��11(�6J   $��Medium"�6X   
�������5�   7   5�   +   5�   '   5�   #   �� 5�   "   $��2��6)   
������ $ 6��5�   (   $ 8q�69   $
 Hand��6E   ._�5�   &   �� $	��⋯��60   $��16(�69   $
��Bold"�6G   #��[ 5�   /   5�   #   5�      5�      5�      5�      5�      �� 5�      $��2��6   #��[ 6%   #��[ 5�      $��1,0,0,0q�6?   ._�5�      �� $
��Auto=�6   .��5�      �� $��24,32,24,24q�6!   .+�5�      �� $��Estadísticas��6$   $��18(�68   $��Medium"�6F   #��[ 5�   #   $��0,0,0,24q�6M   �� 5�      #��[ 6!   $ 12��6L   $ 20,16q�5       $��0,0,0,16q�60   ._�5     �� .+�5  "   �� $��12��6,   $��32(�66   $
��Bold"�6D   #��[ 5  +   $��Center=�5  +   �� 5  "   $��Tareas Pendientes��6,   $��14(�6E   #��[
 5  +   $��Center=�5  +   5     5	     �� 5     #��[ 6!   $ 12��6L   $ 20,16q�5      $��0,0,0,16q�60   ._�5     �� .+�5  "   �� $��8��6,   $��32(�65   $
��Bold"�6C   #��[	 5  +   $��Center=�5  +   �� 5  "   $��Completadas Hoy��6,   $��14(�6C   #��[
 5  +   $��Center=�5  +   5     5     �� 5     #��[ 6!   $ 12��6L   $ 20,16q�5      $��0,0,0,32q�60   ._�5     �� .+�5  "   �� $	��75%��6,   $��32(�67   $
��Bold"�6E   #��[ 5  +   $��Center=�5  +   �� 5  "   $��Productividad��6,   $��14(�6A   #��[
 5   +   $��Center=�5!  +   5"     5#     �� 5%     $��Próximas Fechas��6$   $��16(�6;   $��Medium"�6I   #��[ 5&  #   $��0,0,0,16q�6M   �� 5)     #��[ 6!   $ 8��6L   $ 16,12q�5*      $��0,0,0,8q�60   ._�5+     �� .+�5,  "   �� $��Presentación cliente��6,   $��14(�6H   $��Medium"�6V   #��[ 5-  +   �� 5.  "   $��Mañana 10:00 AM��6,   $��12(�6C   #��[
 5/  +   50     51     �� 54     #��[ 6!   $ 8��6L   $ 16,12q�55      $��0,0,0,8q�60   ._�56     �� .+�57  "   �� $��Entrega final��6,   $��14(�6A   $��Medium"�6O   #��[ 58  +   �� 59  "   $��Viernes 5:00 PM��6,   $��12(�6C   #��[
 5:  +   5;     5<     5=     5>     5?     5@     5A     5B     