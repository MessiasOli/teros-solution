import { DatabaseStatus } from "../enums/DataBaseStatus";

export interface IConfiguration {
    lastUpdate: string,
    lastSystemUpdate: string,
    statusDatabase: DatabaseStatus,
}