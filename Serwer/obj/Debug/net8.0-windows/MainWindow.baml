   M S B A M L   `   `   `  ����
  Serwer    Serwer.ServerWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
TCP Server��5   	   $	��350��6   $	��565��6)    � Icon$ /Images/Logo.ico��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��IP Address:��6   $
��Left=�6&   $��Center=�6A   �� 5   
   -   5         ��Name$ 	IPTextBox��5      $��0��6%   $
��Left=�62   $��Center=�6M   $��	100,0,0,0q�6h   $	��200��6{   �� 5   
   $��Port:��6   $��0��6    $
��Left=�6-   $��Center=�6H   $��	350,0,0,0q�6c   �� 5   
   -   5        $ PortTextBox��5      $��0��6'   $
��Left=�64   $��Center=�6O   $��	400,0,0,0q�6j   $��50��6}   �� 5   
   -   5         ��Name$ StartButton��5      $��0��6&   $��Start��63   $
��Left=�6C   $��Center=�6^   $��	475,0,0,0q�6y   $��50��6�   6�   �� 5   
   -   5         ��Name$ StatusLabel��5      $��1��6%   $��Center=�62   $��Center=�6O   �� 5   
   -   5        $ ReceivedTextBox��5      $��2��6+   $��Stretch=�68   $��Stretch=�6V   $��10q�6r    �� 
IsReadOnly$
 True��6~    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn$
 True��6�   5      5      