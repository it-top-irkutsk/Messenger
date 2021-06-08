# Коды цветовых решений
## Для применения при разработке интерфейсного решения программы
```sh
Цвет бордера главного окна - #272537
Цвет внутреннего блока диалоговых окон - #FF1C163C
Цвет кнопок - #272537
```
## Стили кнопок (Основные моменты. Многоточия заменить на необходимые параметры):
```sh
<Border HorizontalAlignment="Center" CornerRadius="10" BorderThickness="1" Background="Black" .....>
<Button Style="{StaticResource Super_button}" FontSize="22" ....." />
```
### Стиль для кнопки:
```sh
<Window.Resources>
        <Style x:Key="Super_button" TargetType="Button">
            <Setter Property="OverridesDefaultStyle" Value="True" />
            <Setter Property="Background" Value="#272537"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="Button">
                        <Border Name="Border" BorderThickness="0" BorderBrush="Black" Background="{TemplateBinding Background}">
                            <ContentPresenter HorizontalAlignment="Center" VerticalAlignment="Center"/>
                        </Border>
                        <ControlTemplate.Triggers>
                            <EventTrigger RoutedEvent="PreviewMouseDown">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <ThicknessAnimation Storyboard.TargetProperty="Margin" Duration="0:0:0.100" To="2,2,0,0"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                            <EventTrigger RoutedEvent="PreviewMouseUp">
                                <BeginStoryboard>
                                    <Storyboard>
                                        <ThicknessAnimation Storyboard.TargetProperty="Margin" Duration="0:0:0.100" To="0"/>
                                    </Storyboard>
                                </BeginStoryboard>
                            </EventTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
```

**С уважением, ваш коллега по цеху.**