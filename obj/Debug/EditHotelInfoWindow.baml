   M S B A M L   `   `   `  ����W  SPuteshestviePoRossiiGilyazov, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PuteshestviePoRossiiGilyazovPuteshestviePoRossiiGilyazov  5   	   6    0PuteshestviePoRossiiGilyazov.EditHotelInfoWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:PuteshestviePoRossiiGilyazov     5   	     � Title$6  0Окно редактирования отеля��5   	   $	��600��6+   $
��1000��68   $	��600��6E   $
��1000��6U   .��5	      �  � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� $"��Название отеля:��6   $��16(�6*   $��Comic Sans MS)�68   $��0��6S   $��10q�6`   $��Right=�6l   $��Center=�6�   6�   �� 5   
   $&�� Количество звезд:��6   $��16(�6,   $��Comic Sans MS)�6:   $��1��6U   $��10q�6b   $��Right=�6n   $��Center=�6�   6�   �� 5   
   $"��Описание отеля:��6   $��16(�6*   $��Comic Sans MS)�68   $��2��6S   $��10q�6`   $��Right=�6l   $��Center=�6�   6�   �� 5   
   $��Страна:��6   $��16(�6"   $��Comic Sans MS)�60   $��3��6K   $��10q�6X   $��Right=�6d   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ TxtNameHotel��5      $��16(�6(   $��Comic Sans MS)�66   $��0��6Q   $��1��6^   $	��200��6n   $
��Left=�6z   $��Center=�6�   6�   �� 5   
   -   5        $ TxtCountStars��5      $��16(�6)   $��Comic Sans MS)�67   $��1��6R   $��1��6_   $	��200��6o   $
��Left=�6{   $��Center=�6�   6�   �� 5   
   -   5        $ TxtDescriptionHotel��5      $��16(�6/   $��Comic Sans MS)�6=   $��2��6X   $��1��6e   $	��200��6u   $
��Left=�6�   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ CmbNameCountry��5      $��16(�6+   $��Comic Sans MS)�69   $��3��6T   $��1��6a    �� DisplayMemberPath$
 Name��6q   $	��200��6�   $
��Left=�6�   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ BtnDeleteHotel��5      $��16(�6)   $��Comic Sans MS)�67   $��Удалить��6o   $��4��6�   $��0��6�   $	��200��6�   $��70��6�   $��10q�6�   $��Right=�6�   $��Center=�6�   6�   �� 5   
   -   5        $ BtnUpdateHotelInfo��5      $��16(�6-   $��Comic Sans MS)�6;   $��Обновить��6w   $��4��6�   $��1��6�   $	��200��6�   $��70��6�   $
��Left=�6�   $��Center=�6�   6�   5      5       