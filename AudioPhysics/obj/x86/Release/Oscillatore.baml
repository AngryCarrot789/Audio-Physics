   M S B A M L   `   `   `  ���� G  CAudioPhysics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:AudioPhysicsAudioPhysics      AudioPhysics.Oscillatore   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ,localclr-namespace:AudioPhysics     .��� $��0,0,0,0q�.+��� -     ��Name$  lbl_Name��$
��Onda��$
��Left=�$	��Top=�$��Segoe UI Light)�$��16(�$��42��
�������$��6,9,0,0q�� $��60��$	��200��$
��Left=�$��	10,32,0,0q� � ColumnDefinitions �� $��1* ��� $��1 ��� $��1* ��� $��1 ��� $��1* � � RowDefinitions �� $��1* ��� $��1* �.+�	� -    	�Name$ rb_Sin��$��0�� d� 	IsChecked$
 TrueY�.��� .+��� $��Assets/Sin.png��$��32��$��32�� �� BitmapScalingMode$
 Fant=� �� EdgeMode$ Aliased=�	� -   $ rb_Tri��$��2��.��� .+��� $��Assets/Tri.png��$��32��$��32��$
 Fant=�$ Aliased=�	� -   $ rb_Quad��$��4��.��� .+��� $��Assets/Quad.png��$��32��$��32��$
 Fant=�$ Aliased=�	� -   $ rb_Cos��$��1��.��� .+��� $��Assets/Cos.png��$��32��$��32��$
 Fant=�$ Aliased=�	� -   $ rb_Saw��$��1��$��2��.��� .+��� $��Assets/Saw.png��$��32��$��32��$
 Fant=�$ Aliased=�	� -   $ 	rb_Random��$��1��$��4��.��� .+��� $��Assets/Rnd.png��$��32��$��32��$
 Fant=�$ Aliased=��� $��210,15,0,15q�$��1��
�������$
��Left=��� -    ��Name$ AmplitudeSlider��   Horizontal_Slider#��[  $��
292,5,86,0q�$	��Top=� � Maximum$	 100Q�	 � Value$		 100Q��� -	   $ FrequencySlider��#��[  $��292,27,86,0q�$	��Top=�
 � Minimum$
 20Q�$ 20000Q�$		 110Q��� -
   $ DetuneSlider��#��[  $��292,50,86,0q�$	��Top=�$	 100Q�$

 -100Q��� -   $ SfasamentoSlider��#��[  $��292,74,86,0q�$	��Top=�$	 180Q�$

 -180Q��� -    ��Name$ 	tb_Detune��$��Center=�$��21��$��	0,51,30,0q� �� TextWrapping$
 Wrap=�$	��Top=����	#FF25A581���	#FFAEAEAE
���   �$��Segoe UI Light)�$��13.333(�$��Right=�$��51������  �� ElementName$ DetuneSlider�� �� Path$ Value��� -   $ tb_Frequency��$��Center=�$��21��$��	0,28,30,0q�$
 Wrap=�$	��Top=����	#FF25A581���	#FFAEAEAE
���   �$��Segoe UI Light)�$��13.333(�$��Right=�$��51������ $ FrequencySlider��$ Value��� -   $ tb_Amplitude��$��Center=�$��21��$��0,5,30,0q�$
 Wrap=�$	��Top=����	#FF25A581���	#FFAEAEAE
���   �$��Segoe UI Light)�$��13.333(�$��Right=�$��51������ *Value+$ AmplitudeSlider���� -   $ tb_Sfasamento��$��Center=�$��22��$��	0,74,30,0q�$
 Wrap=�$	��Top=����	#FF25A581���	#FFAEAEAE
���   �$��Segoe UI Light)�$��13.333(�$��Right=�$��51��$��1q����� *Value+$ SfasamentoSlider���� -   $  lbl_FrequencyHz��$��Hz��$��0,24,5,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$��Right=�$��25���� -   $  lbl_Percentage��$	��+/-��$��0,47,0,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$��Right=�$��29���� -   $  
lbl_Volume��$��Volume:��$��	216,0,0,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$
��Left=�$��71���� -   $  lbl_Frequency��$��
Frequenza:��$��
216,23,0,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$
��Left=�$��71���� -   $  
lbl_Detune��$��Detune:��$
��Left=�$��
216,46,0,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(��� -   $  lbl_Sfasamento��$��Sfasamento:��$
��Left=�$��
216,70,0,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(��� -   $  lbl_VolumePercentuale��$��%��$��0,2,5,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$��Right=�$��25���� -   $  	lbl_Gradi��$	��Rad��$��
0,71,-11,0q�$	��Top=�
�������$��Segoe UI Light)�$��13.333(�$��Right=�$��40�� � ContextMenu �� .@�m� -    m�Name$ m_dPI��$	��2π��m� -   $ m_tdPI��$��3/2π��m� -   $
 m_PI��$��π��m� -   $ m_hPI��$
��π/2��m� -   $	 m_z��$��0��m� -   $ m_mhPI��$��-π/2��m� -   $ m_mPI��$	��-π��m� -   $ m_mtdPI��$��-3/2π��m� -    $ m_mdPI��$
��-2π���� -!   $  lbl_Channel��$��CANALE��$
��Left=�$	��Top=�$��Segoe UI Light)�$��10.667(�$��29��
�������$��6,-4,0,0q�