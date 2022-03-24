import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function TPReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ThirdParty Application - Reports'})}</PageTitle>
        THIRDPARTY APPLICATION - REPORTS
    </div>
}