
//export interface Welcome {
//    statusCode: number;
//    isSuccess: boolean;
//    description: null;
//    data: Data;
//}

export class EventData {
    eventId: number;
    createTime: string;
    strCreatedTime: string;
    invitations: Invitation[];
};

export class Invitation {
    id: number;
    name: string;
    email: string;
    mobile: string;
    content: string;
    status: number;
    createTime: string;
    strCreatedTime: null;
    requestSentTime: null;
    strRequestSentTime: null;
    responseTime: null;
    strResponseTime: null;
};


export class EventHeader {
    createdTime: string;
    startTime: string;
    numberOfTeacher: number;
    teacherCovered: string;
    classCovered: string;
    reasonForAbsense: string;
};

