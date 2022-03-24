import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function GPMANAGE() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'GlobalPAY Application - Management'})}</PageTitle>
        GLOBALPAY APPLICATION - MANAGEMENT
    </div>
}