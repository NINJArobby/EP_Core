import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function GPReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'GlobalPAY Application - Reports'})}</PageTitle>
        GLOBALPAY APP
    </div>
}