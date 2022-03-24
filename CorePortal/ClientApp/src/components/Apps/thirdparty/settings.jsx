import React from 'react';
import {useIntl} from "react-intl";
import {PageTitle} from "../../../_metronic/layout/core";

export function TPSettings() {
    const intl = useIntl()
    return <div>
        <PageTitle breadcrumbs={[]}>{intl.formatMessage({id: 'ThirdParty APPLICATION - Settings'})}</PageTitle>
        THIRDPARTY APPLICATION - SETTINGS
    </div>
}