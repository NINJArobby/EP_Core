import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function GPSettings() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'GlobalPAY Application - Settings'})}</PageTitle>
        GLOBALPAY APPLICATION - SETTINGS
    </div>
}