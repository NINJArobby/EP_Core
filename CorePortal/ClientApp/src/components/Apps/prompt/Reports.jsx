import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function PMReports() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ZPrompt Application - Reports'})}</PageTitle>
        ZPROMPT APPLICATION - REPORTS
    </div>
}