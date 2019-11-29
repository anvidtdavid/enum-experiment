export interface EnumDescriptor {
    name: string;
    displayInfo: { [key: string]: EnumDisplayInfo };
}

export interface EnumDisplayInfo {
    display: string;
    description: string;
}
