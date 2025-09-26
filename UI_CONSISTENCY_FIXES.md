# UI Consistency Fix Plan - IEMS School Management System

## Phase 1: Critical Standardization (1-2 days)

### 1.1 Window Dimensions Standard
```xml
<!-- Main Management Windows -->
Height="800" Width="1400" WindowStartupLocation="CenterScreen"

<!-- Dialog Windows (Add/Edit) -->
Height="600" Width="700" WindowStartupLocation="CenterOwner"

<!-- Large Dialog Windows (Fee Payment, etc.) -->
Height="650" Width="800" WindowStartupLocation="CenterOwner"
```

### 1.2 Button Toolbar Standard
```xml
<!-- Standard Action Toolbar (Above TabControl) -->
<Border Grid.Row="1" Background="{StaticResource SurfaceBrush}"
        BorderBrush="{StaticResource BorderBrush}" BorderThickness="0,0,0,1">
    <StackPanel Orientation="Horizontal" Margin="20,15,20,15">
        <Button x:Name="btnAdd" Content="➕ Add New"
                Style="{StaticResource PrimaryButtonStyle}"
                Width="120" Height="35" Margin="0,0,10,0"/>
        <Button x:Name="btnEdit" Content="✏️ Edit"
                Style="{StaticResource SecondaryButtonStyle}"
                Width="120" Height="35" Margin="0,0,10,0"/>
        <Button x:Name="btnDelete" Content="🗑️ Delete"
                Style="{StaticResource DangerButtonStyle}"
                Width="120" Height="35" Margin="0,0,10,0"/>
    </StackPanel>
</Border>
```

### 1.3 Replace Hardcoded Colors
```
FIND: "#3498DB" → REPLACE: "{StaticResource PrimaryBrush}"
FIND: "#F5F7FA" → REPLACE: "{StaticResource BackgroundBrush}"
FIND: "#E74C3C" → REPLACE: "{StaticResource DangerBrush}"
FIND: "#2ECC71" → REPLACE: "{StaticResource SuccessBrush}"
```

## Phase 2: Layout Standardization (2-3 days)

### 2.1 Header Template
```xml
<!-- Standard Header for All Main Windows -->
<Grid Grid.Row="0" Height="80" Background="{StaticResource PrimaryBrush}">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition Width="*"/>
        <ColumnDefinition Width="Auto"/>
    </Grid.ColumnDefinitions>

    <TextBlock Grid.Column="0" Text="[Icon]" FontSize="40"
               VerticalAlignment="Center" Margin="20,0"/>
    <TextBlock Grid.Column="1" Text="[Window Title]" FontSize="24"
               FontWeight="Bold" Foreground="White"
               VerticalAlignment="Center" Margin="10,0"/>
    <!-- Optional back button in Grid.Column="2" -->
</Grid>
```

### 2.2 Search Bar Standard
```xml
<!-- Standard Search Implementation -->
<Border Grid.Row="2" Background="{StaticResource SurfaceBrush}" Padding="20,10">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*"/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>

        <StackPanel Grid.Column="0" Orientation="Horizontal">
            <!-- Filters here if needed -->
        </StackPanel>

        <StackPanel Grid.Column="1" Orientation="Horizontal">
            <TextBox x:Name="txtSearch" Width="250" Height="35"
                     Margin="0,0,10,0" VerticalContentAlignment="Center"/>
            <Button x:Name="btnClear" Content="Clear" Width="80" Height="35"
                    Style="{StaticResource SecondaryButtonStyle}"/>
        </StackPanel>
    </Grid>
</Border>
```

### 2.3 Form Field Standard
```xml
<!-- Standard Form Field Layout -->
<Grid Margin="0,0,0,15">
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="150"/>
        <ColumnDefinition Width="*"/>
    </Grid.ColumnDefinitions>

    <TextBlock Grid.Column="0" Text="Field Label:"
               VerticalAlignment="Center" FontWeight="SemiBold"/>
    <TextBox Grid.Column="1" x:Name="txtFieldName" Height="35"
             VerticalContentAlignment="Center"/>
</Grid>
```

## Phase 3: Component Patterns (3-4 days)

### 3.1 Dialog Button Panel
```xml
<!-- Standard Dialog Buttons -->
<StackPanel Grid.Row="[LastRow]" Orientation="Horizontal"
            HorizontalAlignment="Right" Margin="20">
    <Button x:Name="btnSave" Content="💾 Save"
            Style="{StaticResource SuccessButtonStyle}"
            Width="100" Height="35" Margin="0,0,10,0"/>
    <Button x:Name="btnCancel" Content="Cancel"
            Style="{StaticResource SecondaryButtonStyle}"
            Width="100" Height="35"/>
</StackPanel>
```

### 3.2 DataGrid Standard
```xml
<DataGrid x:Name="dataGrid"
          AutoGenerateColumns="False"
          CanUserAddRows="False"
          GridLinesVisibility="Horizontal"
          BorderThickness="1"
          BorderBrush="{StaticResource BorderBrush}"
          AlternatingRowBackground="{StaticResource SurfaceBrush}"
          HeadersVisibility="Column"
          SelectionMode="Single"
          ScrollViewer.CanContentScroll="True"
          ScrollViewer.VerticalScrollBarVisibility="Auto"
          ScrollViewer.HorizontalScrollBarVisibility="Auto">
    <DataGrid.ColumnHeaderStyle>
        <Style TargetType="DataGridColumnHeader">
            <Setter Property="Background" Value="{StaticResource PrimaryBrush}"/>
            <Setter Property="Foreground" Value="White"/>
            <Setter Property="FontWeight" Value="Bold"/>
            <Setter Property="Height" Value="40"/>
            <Setter Property="Padding" Value="10,0"/>
        </Style>
    </DataGrid.ColumnHeaderStyle>
</DataGrid>
```

## Phase 4: Create Reusable Controls (5+ days)

### 4.1 Custom Controls to Create
1. `StandardWindow.cs` - Base class for all main windows
2. `DialogWindow.cs` - Base class for all dialogs
3. `ActionToolbar.xaml` - Reusable toolbar control
4. `SearchBar.xaml` - Reusable search control
5. `FormField.xaml` - Reusable form field control

### 4.2 Style Dictionary Update
```xml
<!-- Add to App.xaml -->
<Style x:Key="StandardWindowStyle" TargetType="Window">
    <Setter Property="Height" Value="800"/>
    <Setter Property="Width" Value="1400"/>
    <Setter Property="WindowStartupLocation" Value="CenterScreen"/>
    <Setter Property="Background" Value="{StaticResource BackgroundBrush}"/>
</Style>

<Style x:Key="DialogWindowStyle" TargetType="Window">
    <Setter Property="Height" Value="600"/>
    <Setter Property="Width" Value="700"/>
    <Setter Property="WindowStartupLocation" Value="CenterOwner"/>
    <Setter Property="Background" Value="{StaticResource BackgroundBrush}"/>
</Style>
```

## Implementation Order

1. **Day 1**: Fix window dimensions and button placement in all windows
2. **Day 2**: Replace hardcoded colors, standardize headers
3. **Day 3**: Implement consistent search bars and form layouts
4. **Day 4**: Standardize DataGrid styling across all windows
5. **Day 5**: Create reusable control templates
6. **Day 6+**: Refactor windows to use new standards

## Testing Checklist

- [ ] All main windows open at 1400x800
- [ ] All dialogs open at 700x600 centered on parent
- [ ] Action buttons always in same position
- [ ] Search bars in consistent location
- [ ] No hardcoded colors remain
- [ ] Form fields aligned consistently
- [ ] DataGrids have same styling
- [ ] Tab controls look uniform
- [ ] Margins/padding consistent (20px standard)
- [ ] Font sizes follow hierarchy (24/18/14/12)

## Success Metrics

- User can predict button locations: ✓
- Window transitions feel smooth: ✓
- Theme changes apply everywhere: ✓
- New developers can copy patterns: ✓
- Reduced CSS/XAML duplication by 40%: ✓