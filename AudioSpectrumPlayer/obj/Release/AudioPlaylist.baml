   M S B A M L   `   `   `  ���� N  JAudioSpectrumPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:AudioSpectrumPlayerAudioSpectrumPlayer  '    !AudioSpectrumPlayer.AudioPlaylist   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     3local!clr-namespace:AudioSpectrumPlayer     $	��250��  � DataContext  ��  �� RelativeSource �� *Self+ � 	Resources    
HideButton �� 
TargetType �� Property �� Value �� 
TargetType ��Name � Points	 �� Stretch
 �� Triggers P� Property P� Value  
ShowButton��%h  &	        &	 .    �� " ��.���  � ��$ 0q���  �@J�Opacity �� *OpacityColor+��  � �� �� *
FirstColor+��  � �� �� *SecondColor+��  � ��$
 Bold"���  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� #��z��.+��� $ MyContentPresenter��#��z��$��Center=�$��Center=��  �   �� �� $
	 Fill=�$��	5,10,5,10q�#��z��$��0��
 P�  �@J�IsMouseOver . . ���  �@J�Opacity$ 1Q���  � �� �� *SecondColor+��  � �� �� *
FirstColor+�� " ��.���  � ��$ 0q���  �@J�Opacity �� *OpacityColor+��  � �� �� *
FirstColor+��  � �� �� *SecondColor+��  � ��$
 Bold"���  � ��$ Center=���  � ��$ Center=���  � �� �� " ��.R�� #��z��.+��� $ MyContentPresenter��#��z��$��Center=�$��Center=��  �   �� �� $
	 Fill=�$��5q�#��z��$��0��
 P�  �@J�IsMouseOver . . ���  �@J�Opacity$ 1Q���  � �� �� *SecondColor+��  � �� �� *
FirstColor+.���  � ColumnDefinitions �� $��8* ��� $��* ��� $��* � � RowDefinitions �� $��* ��� $
��Auto �.+��� -   $��
buttonHide��$��2��$��0��#��[  $y�Visible=����� *ActualWidth+ �� *Self+�� -   $��
buttonShow��$��2��$��0��#��[ $y�	Collapsed=����� *ActualWidth+ �� *Self+