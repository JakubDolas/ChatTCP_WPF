   M S B A M L   `   `   `  ����
  Klient    Klient.ClientWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  
TCP Client��5   	   $	��550��6   $	��525��6)    � Icon$ /Images/Logo.ico��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   .+�5   
   �� $��IP Address:��6   $
��Left=�6&   $��Center=�6A   �� 5   
   -   5         ��Name$ 	IPTextBox��5      $��0��6%   $
��Left=�62   $��Center=�6M   $��	100,0,0,0q�6h   $	��200��6{   �� 5   
   $��Port:��6   $
��Left=�6    $��Center=�6;   $��	319,0,0,0q�6V   �� 5   
   -   5        $ PortTextBox��5      $
��Left=�6'   $��Center=�6B   $��	369,0,0,0q�6]   $��50��6p    J� RenderTransformOrigin$ 
0.08,0.745&�6{   �� 5   
   -   5         ��Name$ ConnectButton��5      $��Connect��6(   $
��Left=�6:   $	��Top=�6U   $��	445,0,0,0q�6m   $��62��6�   $��30��6�   $��2��6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ StatusLabel��5      $��1��6%   $��Center=�62   $��Center=�6O   �� 5   
   -   5        $ MessageTextBox��5      $��2��6*   $	��Top=�67   $��10,406,10,0q�6O    �� AcceptsReturn$
 True��6d   $��36��6y   $��16(�6�   �� 5   
   -   5        $ 
SendButton��5      $��2��6%   $
��Send��62   $��Right=�6A   $	��Top=�6]   $��
0,405,10,0q�6u   $��90��6�   $��38��6�   $
��Bold"�6�   $��18(�6�   �� 5   
   -   5        $ ReceivedTextBox��5      $��2��6+   $��10,24,10,92q�68    �� 
IsReadOnly$
 True��6M   	 �� TextWrapping$
	 Wrap=�6_   $
 True��6s   5      5      