   M S B A M L   `   `   `  ����N  JAudioSpectrumPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AudioSpectrumPlayerAudioSpectrumPlayer  5      '    !AudioSpectrumPlayer.AudioPlaylist   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:AudioSpectrumPlayer     5      $	��250��5        � DataContext  5	      ��  �� RelativeSource �� *Self+ � 	Resources 5         
HideButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name � Points	 �� Stretch
 �� Triggers P� Property P� Value  
ShowButton��%p  &	        &	 �    �� 5   
   " ��6#   .�5      ��  � ��$ 0q�60   6<   �� 5       �@J�Opacity 6(   �� *OpacityColor+6I   �� 5       � �� 6+   �� *
FirstColor+6J   �� 5       � �� 6+   �� *SecondColor+6K   �� 5       � ��$
 Bold"�6+   6:   �� 5       � ��$ Center=�69   6J   �� 5       � ��$ Center=�6;   6L   �� 5       � �� 5      �� 5      " ��6&   .R�5      � #��z��6   .+�5      �� $ MyContentPresenter��6/   #��z��5   +   $��Center=�5   +   $��Center=�5   +   � 5       �   �� �� $
	 Fill=�6C   $��	5,10,5,10q�6R   #��z��6e   $��0��6�   6�   5      5      5       
 5!      P� 5"       �@J�IsMouseOver . . �5#      ��  �@J�Opacity$ 1Q�60   6<   �� 5$       � �� 63   �� *SecondColor+6S   �� 5%       � �� 63   �� *
FirstColor+6R   5&      5(      �� 5)   
   " ��6#   .�5*      ��  � ��$ 0q�60   6<   �� 5+       �@J�Opacity 6(   �� *OpacityColor+6I   �� 5,       � �� 6+   �� *
FirstColor+6J   �� 5-       � �� 6+   �� *SecondColor+6K   �� 5.       � ��$
 Bold"�6+   6:   �� 5/       � ��$ Center=�69   6J   �� 50       � ��$ Center=�6;   6L   �� 51       � �� 52      �� 53      " ��6&   .R�54      � #��z��6   .+�55      �� $ MyContentPresenter��6/   #��z��56   +   $��Center=�57   +   $��Center=�58   +   � 59       �   �� �� $
	 Fill=�6C   $��5q�6R   #��z��6]   $��0��6�   6�   5:      5;      5=      
 5>      P� 5?       �@J�IsMouseOver . . �5@      ��  �@J�Opacity$ 1Q�60   6<   �� 5A       � �� 63   �� *SecondColor+6S   �� 5B       � �� 63   �� *
FirstColor+6R   5C      5E      5F      .��5G      �  � ColumnDefinitions 5H   
   �� 5I      $��8* �6   6,   �� 5J      $��* �6   6+   �� 5K      $��* �6   6+    � RowDefinitions 5M   
   �� 5N      $��* �6   6)   �� 5O      $
��Auto �6   6,   .+�5Q   
   �� -   5        $��
buttonHide��5Q      $��2��6#   $��0��63   #��[  6@   $y�Visible=�6�   ��6d   �� *ActualWidth+ �� *Self+6�   �� 5R   
   -   5        $��
buttonShow��5R      $��2��6#   $��0��63   #��[ 6@   $y�	Collapsed=�6�   ��6d   �� *ActualWidth+ �� *Self+6�   5S      5T      