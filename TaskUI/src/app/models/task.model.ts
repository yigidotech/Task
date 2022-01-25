export class TaskModel {
    id!: number;
    insertDate!: string;
    lastUpdateDate!: string;
    createdBy!: number;
    isActive!: boolean;
    isDeleted!: boolean;
    guid!: string;
    title!: string;
    description!: string;
    isCompleted!:boolean;
    static columns = [
        "IS COMPLETED"
        ,"ID"
        , "INSERT DATE"
        , "LAST UPDATE DATE"
        , "CREATED BY"
        , "IS ACTIVE"
        , "IS DELETED"
        , "GUID"
        , "TITLE"
        , "DESCRIPTION"
    ]
    // static icolumns:IColumnModel[] =[
    //     new this.icolumns()
    // ];
}